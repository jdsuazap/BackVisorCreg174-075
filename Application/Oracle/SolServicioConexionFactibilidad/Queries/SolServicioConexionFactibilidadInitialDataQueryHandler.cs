namespace Application.Oracle.SolServicioConexionFactibilidad.Queries
{
    using Application.Oracle.SolServicioConexionFactibilidad.DTOs;
    using Core.Enumerations;
    using Core.Interfaces.Oracle;
    using MediatR;

    public class SolServicioConexionFactibilidadInitialDataQueryHandler : IRequestHandler<SolServicioConexionFactibilidadInitialDataQuery, DatosAnexosDTO>
    {
        private readonly IDocumentosXformularioService _documentosXformularioService;

        public SolServicioConexionFactibilidadInitialDataQueryHandler(IDocumentosXformularioService documentosXformularioService)
        {
            _documentosXformularioService = documentosXformularioService;
        }


        public async Task<DatosAnexosDTO> Handle(SolServicioConexionFactibilidadInitialDataQuery request, CancellationToken cancellationToken)
        {
            var result = new DatosAnexosDTO();

            List<int> forms = new List<int> {
                (int)FormularioPrincipalEnum.Creg075_Factibilidad_Requeridos,
                (int)FormularioPrincipalEnum.Creg075_Factibilidad_Anexos
            };

            var entity = await _documentosXformularioService.GetAll(x =>
                forms.Contains(x.CodFormulario)
                && x.Estado.HasValue && x.Estado.Value
            );

            foreach (var item in entity)
            {
                if (item.CodFormulario == (int)FormularioPrincipalEnum.Creg075_Factibilidad_Requeridos)
                {
                    result.DocumentosRequeridosAnexos.Add(
                        new DocumentosRequeridosDTO()
                        {
                            Descripcion = item.Descripcion,
                            IdDocumentoXFormulario = item.Id,
                            Nombre = item.NombreDocumento
                        }
                    );
                }

                if (item.CodFormulario == (int)FormularioPrincipalEnum.Creg075_Factibilidad_Anexos)
                {
                    result.DocumentosAnexos.Add(
                        new DocumentosAnexosDTO()
                        {
                            Descripcion = item.Descripcion,
                            IdDocumentoXFormulario = item.Id,
                            Nombre = item.NombreDocumento
                        }
                    );
                }
            }
            return result;
        }
    }
}
