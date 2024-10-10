using AutoMapper;
using DatabaseModel.Context;
using DatabaseModel.DTO;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Utilities;

namespace ScanBoxWebApi.Implementations
{
    public class UserService(ScanBoxDbContext context, IMapper mapper) : IUserService
    {
        private readonly ScanBoxDbContext _context = context; // работают ли подстановки вне системных классов ASP?
        private readonly IMapper _mapper = mapper; // работают ли подстановки вне системных классов ASP?

        // здесь будет проверка базы данных и поиск юзеров
        // пока что тут заглушка
        public UserDTO? Authenticate(LoginFormDTO loginForm)
        {
            // временный вход по указанным ниже паролям и логинам

            if (loginForm.Username.Equals("Admin") && loginForm.Password.Equals("1234567"))
            {
                return new UserDTO() { Username = "Admin", Role = UserRole.Admin };
            }
            else if (loginForm.Username.Equals("User") && loginForm.Password.Equals("7654321"))
            {
                return new UserDTO() { Username = "User", Role = UserRole.User };
            }

            // реальный код
            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(loginForm.Username));

            if (user is not null)
            {
                bool isValid = Hasher.IsPasswordValid(loginForm.Password, user.Password, user.Salt);
                return _mapper.Map<UserDTO>(user);
            }

            return null;
        }
    }
}
