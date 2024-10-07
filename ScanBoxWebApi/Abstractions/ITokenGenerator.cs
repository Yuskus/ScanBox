using DatabaseModel.DTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ITokenGenerator
    {
        string GetToken(UserDTO userDTO);
    }
}
