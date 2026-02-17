namespace Core.Services.Oracle
{
    using Core.CustomEntities;
    using Core.Entities.Oracle;
    using Core.Enumerations;
    using Core.Exceptions;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class Creg_TransformadorService : ICreg_TransformadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISolConexionAutogenService _solConexionAutogenService;

        public Creg_TransformadorService(IUnitOfWork unitOfWork, 
            ISolConexionAutogenService solConexionAutogenService
        )
        {
            _unitOfWork = unitOfWork;
            _solConexionAutogenService = solConexionAutogenService;
        }


        public async Task<Transfor> GetEntityByCodigo(string codigo)
        {
            return await _unitOfWork.Creg_transformadorRepository.GetEntityByCodigo(codigo);
        }

        public async Task<TransformadorCircuitoDto> GetEntityByCodigoInfo(string codigo)
        {
            return await GetEntityByCodigoInfoEmpresa(codigo, 1, _unitOfWork.Creg_transformadorRepository.GetEntityByCodigoInfo);
        }



        public async Task<Transfor> GetEntityByCodigoCTG(string codigo)
        {
            return await _unitOfWork.Creg_transformadorRepository.GetEntityByCodigoCTG(codigo);
        }

        public async Task<TransformadorCircuitoDto> GetEntityByCodigoInfoCTG(string codigo)
        {
            return await GetEntityByCodigoInfoEmpresa(codigo, 2, _unitOfWork.Creg_transformadorRepository.GetEntityByCodigoInfoCTG);
        }


        #region Metodos privados
        private async Task<TransformadorCircuitoDto> GetEntityByCodigoInfoEmpresa(string codigo, int empresa, Func<string, Task<TransformadorCircuitoDto>> obtenerTrafo)
        {
            var trafo = await obtenerTrafo(codigo);
            if (trafo == null) return null;

            var (CapTotalKw, capDisponibleKw, porcentajeInstalado, _, potencia_reservada) = await CalcularCapacidadTransformador(codigo, empresa, Convert.ToDouble(trafo.Cap_Kva));

            trafo.Gen_Instalada = Convert.ToDecimal(porcentajeInstalado);
            trafo.Cap_Max_Disponible = Convert.ToDecimal(capDisponibleKw);
            
            //trafo.Tot_Cap_Ocupada = (potencia_reservada / (decimal)CapTotalKw);
            trafo.Tot_Cap_Ocupada = potencia_reservada;

            return trafo;
        }

        public async Task<bool> ValidarCapacidadTransformador(int empresa, string codigo, decimal capacidadNominal, int TipoSolicitud)
        {
            //bool empresaExiste = (await _empresasService.GetEmpresas()).Any(x => x.Id == empresa);
            //if (!empresaExiste) throw new BusinessException("La empresa enviada no es válida");

            bool esPereira = empresa == (int)EmpresaEnum.Pereira;

            var optrafo = codigo.Split('-');
            codigo = optrafo[0];

            Transfor? trafo = esPereira ? await GetEntityByCodigo(codigo) : await GetEntityByCodigoCTG(codigo);
            if (trafo == null) throw new BusinessException("El transformador consultado no está activo o el código es inválido.");

            TransformadorCircuitoDto? info = esPereira
                ? await GetEntityByCodigoInfo(codigo)
                : await GetEntityByCodigoInfoCTG(codigo);

            if (info == null) throw new BusinessException("El transformador consultado no contiene información detallada.");

            double capKva = Convert.ToDouble(info.Cap_Kva);
            if (capKva <= 0) throw new ArgumentException("La potencia del transformador ya fue superada.");
            if (capacidadNominal <= 0) throw new ArgumentException("La potencia nominal a instalar no puede ser negativa.");

            var (_, _, _, factorPotencia, potencia_reservada) = await CalcularCapacidadTransformador(codigo, empresa, capKva);

            double capacidadNominalDouble = Convert.ToDouble(capacidadNominal);
            double resultadoOperacion = capacidadNominalDouble / (double)factorPotencia;
            double resultado = capKva - (Convert.ToDouble(potencia_reservada) + resultadoOperacion);

            return resultado > 0;
        }


        public async Task<(double CapTotalKw, double CapDisponibleKw, double PorcentajeInstalado, decimal factorPotencia, decimal potencia_reservada)>
            CalcularCapacidadTransformador(string codigo, int empresa, double capKva)
        {
            decimal factorPotencia = 1, potencia_reservada = 0;

            var potencia = await _unitOfWork.SolConexionAutogenRepository.GetEntitiesTrafo(empresa, codigo);
            
            potencia_reservada = potencia.PotenciaMaximaDeclarada;

            double capTotalKw = Convert.ToDouble(capKva) * Convert.ToDouble(factorPotencia);

            double capDisponibleKw, porcentajeInstalado = 0;
            
            capDisponibleKw = (capTotalKw / 2) - Convert.ToDouble(potencia_reservada);
            porcentajeInstalado = (Convert.ToDouble(potencia_reservada) / capTotalKw) * 100;
                            
            return (capTotalKw, capDisponibleKw, porcentajeInstalado, factorPotencia, potencia_reservada);
        }
        #endregion
    }
}
