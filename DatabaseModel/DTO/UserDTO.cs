namespace DatabaseModel.DTO
{
    public class UserDTO
    {
        public required string Username { get; set; }
        public UserRole Role { get; set; }
    }
    public enum UserRole
    {
        User,
        Admin
    }
}
