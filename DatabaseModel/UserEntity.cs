namespace DatabaseModel
{
    public class UserEntity
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public int Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
