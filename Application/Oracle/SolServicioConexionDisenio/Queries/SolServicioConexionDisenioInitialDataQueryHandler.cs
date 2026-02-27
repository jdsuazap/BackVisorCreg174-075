using Application.Oracle.SolServicioConexionDisenio.DTOs;
using AutoMapper;
using Core.Enumerations;
using Core.Interfaces.Oracle;
using MediatR;

namespace Application.Oracle.SolServicioConexionDisenio.Queries
{
    public class SolServicioConexionDisenioInitialDataQueryHandler : IRequestHandler<SolServicioConexionDisenioInitialDataQuery, DatosAnexosDisenioDTO>
    {
        private readonly IDocumentosXformularioService _documentosXformularioService;

        public SolServicioConexionDisenioInitialDataQueryHandler(IDocumentosXformularioService documentosXformularioService)
        {
            _documentosXformularioService = documentosXformularioService;
        }

        public async Task<DatosAnexosDisenioDTO> Handle(SolServicioConexionDisenioInitialDataQuery request, CancellationToken cancellationToken)
        {
            var result = new DatosAnexosDisenioDTO();
            var forms = new List<int>
            {
                (int)FormularioPrincipalEnum.Creg075_Factibilidad_Requeridos,
                (int)FormularioPrincipalEnum.Creg075_Diseños_Requeridos,
                (int)FormularioPrincipalEnum.Creg075_Diseños_Anexos,
                (int)FormularioPrincipalEnum.Creg075_Revision_Diseño
            };

            var entity = await _documentosXformularioService.GetAll(x => forms.Contains(x.CodFormulario) && x.Estado.HasValue && x.Estado.Value);

            foreach (var item in entity)
            {
                if (item.CodFormulario == (int)FormularioPrincipalEnum.Creg075_Factibilidad_Requeridos)
                {
                    result.DocumentosRequeridosAnexos.Add(new DocumentosRequeridosDisenioDTO()
                    {
                        Descripcion = item.Descripcion,
                        IdDocumentoXFormulario = item.Id,
                        Nombre = item.NombreDocumento,
                        Requiered = item.Requiered
                    });
                }

                if (item.CodFormulario == (int)FormularioPrincipalEnum.Creg075_Diseños_Anexos)
                {
                    result.DocumentosAnexos.Add(new DocumentosAnexosDisenioDTO()
                    {
                        Descripcion = item.Descripcion,
                        IdDocumentoXFormulario = item.Id,
                        Nombre = item.NombreDocumento,
                        Requiered = item.Requiered
                    });
                }

                if (item.CodFormulario == (int)FormularioPrincipalEnum.Creg075_Revision_Diseño)
                {
                    result.DocumentosQuePresenta.Add(new  DocumentosPresentaDisenioDTO()
                    {
                        Descripcion = item.Descripcion,
                        IdDocumentoXFormulario = item.Id,
                        Nombre = item.NombreDocumento,
                        Requiered = item.Requiered
                    });
                }
            }
            return result;
        }
    }
}
