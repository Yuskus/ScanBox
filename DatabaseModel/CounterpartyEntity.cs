namespace DatabaseModel
{
    public class CounterpartyEntity
    {
        public int Id { get; set; }
        public int CounterpartyTypeId { get; set; }
        public virtual CounterpartyTypeEntity? CounterpartyType { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }

        /*- покупатель
        - производитель
        - поставщик
        - документ
        - юридическое
        - физическое лицо*/
    }
}
