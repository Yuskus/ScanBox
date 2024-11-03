using AutoMapper;
using DatabaseModel;
using ScanBoxWebApi.DTO;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;

namespace ScanBoxWebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // чтобы из сущности пользователя создать объект прав пользователя
            CreateMap<UserEntity, UserRightsDTO>();

            // чтобы заполнить бд юзером
            CreateMap<RegisterFormDTO, UserEntity>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());

            // заполнение базы
            CreateMap<BuyerPostDTO, BuyerEntity>();
            CreateMap<CounterpartyPostDTO, CounterpartyEntity>();
            CreateMap<CounterpartyTypePostDTO, CounterpartyTypeEntity>();
            CreateMap<DocumentPostDTO, DocumentEntity>();
            CreateMap<DocumentTypePostDTO, DocumentTypeEntity>();
            CreateMap<JobTitlePostDTO, JobTitleEntity>();
            CreateMap<LegalEntityPostDTO, LegalEntityEntity>();
            CreateMap<LegalFormPostDTO, LegalFormEntity>();
            CreateMap<ManufacturerPostDTO, ManufacturerEntity>();
            CreateMap<MovementHistoryPostDTO, MovementHistoryEntity>();
            CreateMap<PricesPostDTO, PricesEntity>();
            CreateMap<ProductCategoryPostDTO, ProductCategoryEntity>();
            CreateMap<ProductTypePostDTO, ProductTypeEntity>();
            CreateMap<ProductUnitPostDTO, ProductUnitEntity>();
            CreateMap<ShipmentPostDTO, ShipmentEntity>();
            CreateMap<SupplierPostDTO, SupplierEntity>();
            CreateMap<WarehouseEmployeePostDTO, WarehouseEmployeeEntity>();

            // чтение из базы
            CreateMap<BuyerEntity, BuyerGetDTO>();
            CreateMap<CounterpartyEntity, CounterpartyGetDTO>();
            CreateMap<CounterpartyTypeEntity, CounterpartyTypeGetDTO>();
            CreateMap<DocumentEntity, DocumentGetDTO>();
            CreateMap<DocumentTypeEntity, DocumentTypeGetDTO>();
            CreateMap<JobTitleEntity, JobTitleGetDTO>();
            CreateMap<LegalEntityEntity, LegalEntityGetDTO>();
            CreateMap<LegalFormEntity, LegalFormGetDTO>();
            CreateMap<ManufacturerEntity, ManufacturerGetDTO>();
            CreateMap<MovementHistoryEntity, MovementHistoryGetDTO>();
            CreateMap<PricesEntity, PricesGetDTO>();
            CreateMap<ProductCategoryEntity, ProductCategoryGetDTO>();
            CreateMap<ProductTypeEntity, ProductTypeGetDTO>();
            CreateMap<ProductUnitEntity, ProductUnitGetDTO>();
            CreateMap<ShipmentEntity, ShipmentGetDTO>();
            CreateMap<SupplierEntity, SupplierGetDTO>();
            CreateMap<WarehouseEmployeeEntity, WarehouseEmployeeGetDTO>();

            // для сверки отгрузок, на всякий
            CreateMap<ShipmentPostDTO, MovementHistoryPostDTO>().ReverseMap();
            CreateMap<ShipmentGetDTO, MovementHistoryGetDTO>().ReverseMap();
        }
    }
}
