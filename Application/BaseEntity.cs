namespace Application
{
    using Core.ModelResponse;

    public class BaseEntity<T> where T : class
    {
        public List<ResponseAction> ResponseAction = new();
        public T Entity = default;
    }
}
