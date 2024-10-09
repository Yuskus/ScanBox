using DatabaseModel.DTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IUserService
    {
        public UserDTO? Authenticate(LoginFormDTO loginForm);
    }
}
