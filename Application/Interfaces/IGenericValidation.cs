namespace Application.Interfaces
{
    using FluentValidation;
    using FluentValidation.Results;

    public interface IGenericValidation
    {
        Task<ValidationResult> ValidarEntidadAsync<TValidator, TEntity>(TEntity entity, string ruleSet = null)
        where TValidator : AbstractValidator<TEntity>, new();
    }
}
