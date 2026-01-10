namespace Core.Entities
{
    public interface IGenericEntityBase<T>
    {
        T Id { get; set; }
    }
}
