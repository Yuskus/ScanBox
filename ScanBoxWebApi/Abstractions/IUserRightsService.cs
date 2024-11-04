using ScanBoxWebApi.DTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IUserRightsService
    {
        public Task<UserRightsDTO?> Authenticate(LoginFormDTO loginForm);
    }
}
