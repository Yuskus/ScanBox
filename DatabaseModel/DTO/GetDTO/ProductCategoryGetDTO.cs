namespace DatabaseModel.DTO.GetDTO
{
    public class ProductCategoryGetDTO
    {
        public int Id { get; set; }
        public required string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
