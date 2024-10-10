п»їusing AutoMapper;
using DatabaseModel.Context;
using DatabaseModel.DTO;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Utilities;

namespace ScanBoxWebApi.Implementations
{
    public class UserService(ScanBoxDbContext context, IMapper mapper) : IUserService
    {
        private readonly ScanBoxDbContext _context = context; // СЂР°Р±РѕС‚Р°СЋС‚ Р»Рё РїРѕРґСЃС‚Р°РЅРѕРІРєРё РІРЅРµ СЃРёСЃС‚РµРјРЅС‹С… РєР»Р°СЃСЃРѕРІ ASP?
        private readonly IMapper _mapper = mapper; // СЂР°Р±РѕС‚Р°СЋС‚ Р»Рё РїРѕРґСЃС‚Р°РЅРѕРІРєРё РІРЅРµ СЃРёСЃС‚РµРјРЅС‹С… РєР»Р°СЃСЃРѕРІ ASP?

        // Р·РґРµСЃСЊ Р±СѓРґРµС‚ РїСЂРѕРІРµСЂРєР° Р±Р°Р·С‹ РґР°РЅРЅС‹С… Рё РїРѕРёСЃРє СЋР·РµСЂРѕРІ
        // РїРѕРєР° С‡С‚Рѕ С‚СѓС‚ Р·Р°РіР»СѓС€РєР°
        public UserDTO? Authenticate(LoginFormDTO loginForm)
        {
            // РІСЂРµРјРµРЅРЅС‹Р№ РІС…РѕРґ РїРѕ СѓРєР°Р·Р°РЅРЅС‹Рј РЅРёР¶Рµ РїР°СЂРѕР»СЏРј Рё Р»РѕРіРёРЅР°Рј

            if (loginForm.Username.Equals("Admin") && loginForm.Password.Equals("1234567"))
            {
                return new UserDTO() { Username = "Admin", Role = UserRole.Admin };
            }
            else if (loginForm.Username.Equals("User") && loginForm.Password.Equals("7654321"))
            {
                return new UserDTO() { Username = "User", Role = UserRole.User };
            }

            // СЂРµР°Р»СЊРЅС‹Р№ РєРѕРґ
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
