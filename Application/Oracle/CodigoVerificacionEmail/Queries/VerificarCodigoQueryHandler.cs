namespace Application.Oracle.Pasarela.Queries
{
    using Application.Interfaces;
    using AutoMapper;
    using Core.Interfaces.Oracle;
    using MediatR;

    internal class VerificarCodigoQueryHandler : IRequestHandler<VerificarCodigoQuery, bool>
    {
        private readonly ICodigoVerificacionService _crearCodigoVerificacionService;
        private readonly IMapper _mapper;
        private readonly IGenericValidation _validator;

        public VerificarCodigoQueryHandler(
            ICodigoVerificacionService crearCodigoVerificacionService,
            IMapper mapper,
            IGenericValidation validator
        )
        {
            _crearCodigoVerificacionService = crearCodigoVerificacionService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> Handle(VerificarCodigoQuery request, CancellationToken cancellationToken)
        {
            //var validationResult = await _validator.ValidarEntidadAsync<PasarelaCreateTransactionCommandValidator, PasarelaCrearCodigoVerificacionCommand>(request, "Create");

            //if (!validationResult.IsValid)
            //{
            //    throw new BusinessException($"Error en las validaciones: {string.Join("|", validationResult.Errors)}");
            //}

            var esValido = _crearCodigoVerificacionService.ValidarCodigoVerificacion(request.Email, request.Codigo);

            return esValido;
        }
    }
}
