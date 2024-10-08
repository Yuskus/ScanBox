using DatabaseModel.DTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Implementations
{
    public class UserService : IUserService
    {
        //здесь будет проверка базы данных и поиск юзеров
        public UserDTO? Authenticate(LoginFormDTO loginForm)
        {
            //пока что тут заглушка
            if (loginForm.Username.Equals("Admin") && loginForm.Password.Equals("1234567"))
            {
                return new UserDTO() { Username = "Admin", Role = UserRole.Admin };
            }
            else if (loginForm.Username.Equals("User") && loginForm.Password.Equals("7654321"))
            {
                return new UserDTO() { Username = "User", Role = UserRole.User };
            }
            return null;
        }
    }
}
