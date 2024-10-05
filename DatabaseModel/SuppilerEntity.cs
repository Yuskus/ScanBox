﻿namespace DatabaseModel
{
    public class SuppilerEntity
    {
        public int Id { get; set; }
        public int LegalEntityId { get; set; }
        public virtual LegalEntityEntity? LegalEntity { get; set; }
        public virtual ICollection<ProductUnitEntity> ProductUnits { get; set; } = [];
    }
}
