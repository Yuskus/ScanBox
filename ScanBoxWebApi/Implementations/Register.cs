using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Utilities;

namespace ScanBoxWebApi.Implementations
{
    public class Register(ScanBoxDbContext context, IMapper mapper) : IRegister
    {
        private readonly ScanBoxDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public int RegisterUser(RegisterFormDTO registerForm)
        {
            if (_context.Users.Any(x => x.Username.Equals(registerForm.Username))) return -1;

            var userEntity = _mapper.Map<UserEntity>(registerForm);
            (byte[] hash, byte[] salt) = Hasher.CreatePasswordHash(registerForm.Password);
            userEntity.Password = hash;
            userEntity.Salt = salt;

            _context.Users.Add(userEntity);
            _context.SaveChanges();
            return userEntity.Id;
        }
        public int UpdateRoleUser(UserRightsDTO UserDTO)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(UserDTO.Username));
            int result = -1;

            if (user is not null)
            {
                user.Role = (int)UserDTO.Role;
                result = user.Id;
                _context.SaveChanges();
            }

            return result;
        }
        public int DeleteUser(string name)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(name));
            int result = -1;

            if (user is not null)
            {
                result = user.Id;
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return result;
        }
    }
}
