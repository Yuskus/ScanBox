namespace DatabaseModel.DTO
{
    public class RegisterFormDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}
