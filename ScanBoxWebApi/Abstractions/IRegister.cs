using ScanBoxWebApi.DTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IRegister
    {
        Task<int> RegisterUser(RegisterFormDTO registerForm);
        Task<int> UpdateRoleUser(UserRightsDTO UserDTO);
        Task<int> DeleteUser(string name);
    }
}
