namespace Core.Entities
{
    public abstract class GenericBaseEntity<T>: DomainEntity, IGenericEntityBase<T>
    {
        public T Id { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }
    }
}
