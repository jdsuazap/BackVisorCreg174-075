namespace Application.Oracle.CodigoVerificacionEmail.Validators
{
    using Application.Oracle.CodigoVerificacionEmail.Commands;
    using Core.Messages;
    using FluentValidation;

    public class CrearCodigoVerificacionCommandValidator : AbstractValidator<CrearCodigoVerificacionCommand>
    {
        public CrearCodigoVerificacionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ErrorMessage.EmptyError)
                .GreaterThan(0);

            RuleFor(x => x.Empresa)
                .NotEmpty().WithMessage(ErrorMessage.EmptyError)
                .GreaterThan(0);
            
            RuleFor(x => x.TipoSolicitud)
                .NotEmpty().WithMessage(ErrorMessage.EmptyError)
                .GreaterThan(0);

        }
    }
}

