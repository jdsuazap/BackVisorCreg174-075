namespace Application
{
    using Core.CustomEntities;
    using Core.ModelResponse;
    using FluentValidation.Results;

    public class EntityResponse<T> //where T : class
    {
        public bool Estado { get; set; }

        public List<ResponseAction> ResponseAction { get; set; } = new List<ResponseAction>();

        public ResponseAction ResponseAction_ { get; set; }

        public T? Entity { get; set; }

        public IList<ValidationFailure> ValidationErrors { get; set; }

        public string ErrorMensaje { get; set; }

        public Metadata Metadata { get; set; }

        public EntityResponse()
        {
            ValidationErrors = new List<FluentValidation.Results.ValidationFailure>();
        }
    }
}
