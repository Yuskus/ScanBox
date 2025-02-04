﻿namespace DatabaseModel
{
    public class ManufacturerEntity
    {
        public int Id { get; set; }
        public int CounterpartyId { get; set; }
        public virtual CounterpartyEntity? Counterparty { get; set; }
        public virtual ICollection<ProductTypeEntity> ProductTypes { get; set; } = [];
    }
}
