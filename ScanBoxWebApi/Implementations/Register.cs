using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ScanBoxWebApi.Implementations
{
    public class Register(ScanBoxDbContext context, IMapper mapper) : IRegister
    {
        private readonly ScanBoxDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<int> RegisterUser(RegisterFormDTO registerForm)
        {
            if (await _context.Users.AnyAsync(x => x.Username.Equals(registerForm.Username))) return -1;

            var userEntity = _mapper.Map<UserEntity>(registerForm);
            (byte[] hash, byte[] salt) = Hasher.CreatePasswordHash(registerForm.Password);
            userEntity.Password = hash;
            userEntity.Salt = salt;

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return userEntity.Id;
        }
        public async Task<int> UpdateRoleUser(UserRightsDTO UserDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username.Equals(UserDTO.Username));
            int result = -1;

            if (user is not null)
            {
                user.Role = (int)UserDTO.Role;
                result = user.Id;
                await _context.SaveChangesAsync();
            }

            return result;
        }
        public async Task<int> DeleteUser(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username.Equals(name));
            int result = -1;

            if (user is not null)
            {
                result = user.Id;
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
