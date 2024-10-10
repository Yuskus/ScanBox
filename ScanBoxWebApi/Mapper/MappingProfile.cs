п»їusing AutoMapper;
using DatabaseModel;
using DatabaseModel.DTO;

namespace ScanBoxWebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // С‡С‚РѕР±С‹ РёР· СЃСѓС‰РЅРѕСЃС‚Рё РїРѕР»СЊР·РѕРІР°С‚РµР»СЏ СЃРѕР·РґР°С‚СЊ РѕР±СЉРµРєС‚ РїСЂР°РІ РїРѕР»СЊР·РѕРІР°С‚РµР»СЏ
            CreateMap<UserEntity, UserDTO>();

            // С‡С‚РѕР±С‹ Р·Р°РїРѕР»РЅРёС‚СЊ 
            CreateMap<LoginFormDTO, UserEntity>();
        }
    }
}
