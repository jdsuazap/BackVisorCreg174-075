namespace Application.Oracle.CodigoVerificacionEmail.Commands
{
    using Application.Interfaces;
    using Application.Oracle.CodigoVerificacionEmail.DTOs;
    using Application.Oracle.CodigoVerificacionEmail.Validators;
    using Application.Oracle.SolServicioConexion.DTOs;
    using AutoMapper;
    using Core.Enumerations;
    using Core.Exceptions;
    using Core.Interfaces.Oracle;
    using MediatR;

    internal class CrearCodigoVerificacionCommandHandler : IRequestHandler<CrearCodigoVerificacionCommand, EnvioCodigoReponse>
    {
        private readonly ICodigoVerificacionService _crearCodigoVerificacionService;
        private readonly IMapper _mapper;
        private readonly IGenericValidation _validator;
        private readonly ISolServicioConexionService _solServicioConexionService;
        private readonly ISolConexionAutogenService _solConexionAutogenService;

        public CrearCodigoVerificacionCommandHandler(
            ICodigoVerificacionService crearCodigoVerificacionService,
            IMapper mapper,
            IGenericValidation validator,
            ISolServicioConexionService solServicioConexionService,
            ISolConexionAutogenService solConexionAutogenService)
        {
            _crearCodigoVerificacionService = crearCodigoVerificacionService;
            _mapper = mapper;
            _validator = validator;
            _solServicioConexionService = solServicioConexionService;
            _solConexionAutogenService = solConexionAutogenService;
        }


        public async Task<EnvioCodigoReponse> Handle(CrearCodigoVerificacionCommand request, CancellationToken cancellationToken)
        {
            string email = "";

            var validationResult = await _validator.ValidarEntidadAsync<CrearCodigoVerificacionCommandValidator, CrearCodigoVerificacionCommand>(request);

            if (!validationResult.IsValid)            
                throw new BusinessException($"Error en las validaciones: {string.Join("|", validationResult.Errors)}");

            if (request.TipoSolicitud == (int)TipoSolicitudEnum.Servicio)
            {
                var solServicio = new SolServicioConexionDTO { Id = request.Id, Empresa = request.Empresa};
                var entity = await _solServicioConexionService.GetEntity(solServicio.Id, solServicio.Empresa);
                email = entity.Creg075Solicitantes.First().Email;
            }
            else 
            {
                var solConAutogen = new Core.Entities.Oracle.Creg174Autogen { Id = request.Id, CodEmpresa = request.Empresa };
                var entity = await _solConexionAutogenService.GetEntity(solConAutogen);
                email = entity.EmailCliente;
            }

            email = "johndasua@hotmail.com";
            await _crearCodigoVerificacionService.GenerarCodigoVerificacion(email, "Código de verificación visualización solicitud", "Verificación de Solicitud");
            
            return new EnvioCodigoReponse { Email = email };
        }
    }
}
