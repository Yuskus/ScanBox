namespace DatabaseModel.DTO.GetDTO
{
    public class ShipmentGetDTO : IEquatable<ShipmentGetDTO>
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int ProductUnitId { get; set; }

        public bool Equals(ShipmentGetDTO? other)
        {
            return DocumentId == other?.DocumentId && ProductUnitId == other?.ProductUnitId;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ShipmentGetDTO);
        }

        public override int GetHashCode()
        {
            return DocumentId.GetHashCode() ^ ProductUnitId.GetHashCode();
        }
    }
}
