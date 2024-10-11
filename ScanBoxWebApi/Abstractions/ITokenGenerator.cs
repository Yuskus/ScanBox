using DatabaseModel.DTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ITokenGenerator
    {
        string GetToken(UserRightsDTO userDTO);
    }
}
