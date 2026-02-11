namespace Application.Oracle.SolServicioConexionFactibilidad.Validators
{
    using Application.Oracle.SolServicioConexionFactibilidad.DTOs;
    using FluentValidation;

    public class SolServicioConexionFactibilidadValidator : AbstractValidator<SolServicioConexionFactibilidadDTO>
    {
        public SolServicioConexionFactibilidadValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleSet("CreateValidation", () =>
            {

            });

            RuleSet("UpdateValidation", () =>
            {

            });
        }
    }
}
