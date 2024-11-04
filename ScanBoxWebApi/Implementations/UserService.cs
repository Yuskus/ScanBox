using AutoMapper;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ScanBoxWebApi.Implementations
{
    public class UserService(ScanBoxDbContext context, IMapper mapper) : IUserRightsService
    {
        private readonly ScanBoxDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task<UserRightsDTO?> Authenticate(LoginFormDTO loginForm)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username.Equals(loginForm.Username));

            if (user is not null)
            {
                bool isValid = Hasher.IsPasswordValid(loginForm.Password, user.Password, user.Salt);

                if (isValid)
                {
                    return _mapper.Map<UserRightsDTO>(user);
                }
            }

            return null;
        }
    }
}
