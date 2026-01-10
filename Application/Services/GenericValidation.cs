namespace Application.Services
{
    using Application.Interfaces;
    using FluentValidation;
    using FluentValidation.Results;

    public class GenericValidation : IGenericValidation
    {
        public async Task<ValidationResult> ValidarEntidadAsync<TValidator, TEntity>(TEntity entity, string ruleSet = null) 
            where TValidator : AbstractValidator<TEntity>, new()
        {
            var validator = new TValidator();

            if (string.IsNullOrEmpty(ruleSet))
                return await validator.ValidateAsync(entity);
            else
                return await validator.ValidateAsync(entity, options => options.IncludeRuleSets(ruleSet));
        }
    }

}