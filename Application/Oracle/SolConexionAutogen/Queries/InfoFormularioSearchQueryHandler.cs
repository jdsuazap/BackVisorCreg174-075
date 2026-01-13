namespace Application.Oracle.SolConexionAutogen.Queries
{
    using Application.Oracle.SolConexionAutogen.DTOs;
    using AutoMapper;
    using Core.CustomEntities;
    using Core.Enumerations;
    using Core.Interfaces.Oracle;
    using MediatR;
    using System.Security.Cryptography.Xml;

    public class InfoFormularioSearchQueryHandler : IRequestHandler<InfoFormularioSearchQuery, InfoFormularioDTO>
    {
        private readonly IMapper _mapper;
        private readonly ISolConexionAutogenService _solConexionAutogenService;
        private readonly ICreg_TransformadorService _TransformadorService;

        public InfoFormularioSearchQueryHandler(
            IMapper mapper,
            ISolConexionAutogenService solConexionAutogenService,
            ICreg_TransformadorService transformadorService
        )
        {
            _mapper = mapper;
            _solConexionAutogenService = solConexionAutogenService;
            _TransformadorService = transformadorService;
        }

        public async Task<InfoFormularioDTO> Handle(InfoFormularioSearchQuery request, CancellationToken cancellationToken)
        {
            var isPereira = request.Empresa == (int)EmpresaEnum.Pereira;

            var infoFormularioDTO = new InfoFormularioDTO();

            if (request.Transformador != null)
            {
                var trafo = isPereira
                    ? await _TransformadorService.GetEntityByCodigo(request.Transformador)
                    : await _TransformadorService.GetEntityByCodigoCTG(request.Transformador);

                TransformadorCircuitoDto entity = isPereira
                    ? await _TransformadorService.GetEntityByCodigoInfo(request.Transformador)
                    : await _TransformadorService.GetEntityByCodigoInfoCTG(request.Transformador);

                            
                infoFormularioDTO.Transformador = request.Transformador.ToString();
                infoFormularioDTO.PorcentajeTransformador = entity.Gen_Instalada.ToString();
                infoFormularioDTO.Cap_Max_Disponible = entity.Cap_Max_Disponible;
                infoFormularioDTO.Tot_Cap_Ocupada = entity.Tot_Cap_Ocupada;

            }


            //if (request.Matricula != null)
            //{
            //    var infoCliente = isPereira
            //        ? await _niuService.GetInfoCliente(request.Matricula)
            //        : await _niuService.GetInfoClienteCTG(request.Matricula);
            //    var Clientedto = _mapper.Map<Custmetr>(infoCliente[0]);

            //    //infoFormularioDTO.Tipo_Uso = Clientedto.Actividad;
            //    infoFormularioDTO.Estrato = Clientedto.Estrato.ToString();

            //    if (infoFormularioDTO.Departamento == null)
            //    {
            //        if (Clientedto.DepId != null)
            //        {
            //            var departamento = _departamentoService.GetEntities().Result.Where(x => x.CodigoDane == Clientedto.DepId.ToString()).Select(x => x.Id).First();
            //            infoFormularioDTO.Departamento = departamento;

            //            string codigo = $"{Clientedto.DepId.ToString()}{Clientedto.Municipio.ToString().PadLeft(3, '0')}";

            //            var municipio = _ciudadService.GetEntities().Result.Where(x => x.CodDepartamento == departamento && x.Id == codigo).Select(x => x.Id).First();
            //            infoFormularioDTO.Municipio = municipio;
            //        }
            //    }
            //}

            //    if (request.TipoNodo.Contains("BT"))
            //    {
            //        var nodosBj = isPereira
            //               ? await _nodosBJService.GetEntityByCodigo(request.CodigoNodo)
            //               : await _nodosBJService.GetEntityByCodigoCTG(request.CodigoNodo);
            //        var nodosBjDto = _mapper.Map<Lvelnode>(nodosBj);

            //        infoFormularioDTO.NodoBT = nodosBjDto.Code;
            //        Coordenadas(infoFormularioDTO, nodosBjDto.Latitud.ToString(), nodosBjDto.Longitud.ToString(), nodosBjDto.Height.ToString());

            //        infoFormularioDTO.Subestacion = nodosBjDto.Fparent.ToString();
            //        if (request.TipoSolicitud == (int)TipoSolicitudEnum.Servicio)
            //            infoFormularioDTO.NivelTension = (nodosBjDto.Kvnom < 1 ? 1 : nodosBjDto.Kvnom).ToString().Replace(",", ".");
            //        else
            //            infoFormularioDTO.NivelTension = nodosBjDto.Kvnom.ToString().Replace(",", ".");
            //    }
            //    else
            //    {
            //        var nodosMT = isPereira
            //            ? await _nodosMTService.GetEntityByCodigo(request.CodigoNodo)
            //            : await _nodosMTService.GetEntityByCodigoCTG(request.CodigoNodo);
            //        var nodosMTDto = _mapper.Map<Mvelnode>(nodosMT);

            //        infoFormularioDTO.NodoMT = nodosMTDto.Code;
            //        Coordenadas(infoFormularioDTO, nodosMTDto.Latitud.ToString(), nodosMTDto.Longitud.ToString(), nodosMTDto.Height.ToString());

            //        infoFormularioDTO.Subestacion = nodosMT.Fparent.ToString();

            //        if (request.TipoSolicitud == (int)TipoSolicitudEnum.Servicio)
            //            infoFormularioDTO.NivelTension = (nodosMT.Kvnom < 1 ? 1 : nodosMT.Kvnom).ToString().Replace(",", ".");
            //        else
            //            infoFormularioDTO.NivelTension = nodosMT.Kvnom.ToString().Replace(",", ".");
            //    }
            return infoFormularioDTO;
        }
       
    }
}
