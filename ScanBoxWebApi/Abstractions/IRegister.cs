using DatabaseModel.DTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IRegister
    {
        int RegisterUser(RegisterFormDTO registerForm);
        int UpdateRoleUser(UserRightsDTO UserDTO);
        int DeleteUser(string name);
    }
}
