namespace ScanBoxWebApi.DTO
{
    public class UserRightsDTO
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
