﻿namespace DatabaseModel
{
    public class ShipmentEntity
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public virtual DocumentEntity? Document { get; set; }
        public int ProductUnitId { get; set; }
        public virtual ProductUnitEntity? ProductUnit { get; set; }
    }
}
