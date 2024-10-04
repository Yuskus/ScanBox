namespace DatabaseModel
{
    public class JobTitleEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? DutiesDescription { get; set; }
        public int BaseSalary { get; set; }
        public virtual ICollection<WarehouseEmployeeEntity> WarehouseEmployees { get; set; } = [];
    }
}
