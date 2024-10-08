using AutoMapper;
using DatabaseModel;
using DatabaseModel.DTO;

namespace ScanBoxWebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // чтобы из сущности пользователя создать объект прав пользователя
            CreateMap<UserEntity, UserDTO>();

            // чтобы заполнить 
            CreateMap<LoginFormDTO, UserEntity>();
        }
    }
}
