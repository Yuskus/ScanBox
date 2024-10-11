using DatabaseModel.DTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IUserRightsService
    {
        public UserRightsDTO? Authenticate(LoginFormDTO loginForm);
    }
}
