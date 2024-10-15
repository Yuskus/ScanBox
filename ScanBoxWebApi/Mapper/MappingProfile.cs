using AutoMapper;
using DatabaseModel;
using DatabaseModel.DTO;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

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
            CreateMap<BuyerGetDTO, BuyerEntity>();
            CreateMap<CounterpartyGetDTO, CounterpartyEntity>();
            CreateMap<CounterpartyTypeGetDTO, CounterpartyTypeEntity>();
            CreateMap<DocumentGetDTO, DocumentEntity>();
            CreateMap<DocumentTypeGetDTO, DocumentTypeEntity>();
            CreateMap<JobTitleGetDTO, JobTitleEntity>();
            CreateMap<LegalEntityGetDTO, LegalEntityEntity>();
            CreateMap<LegalFormGetDTO, LegalFormEntity>();
            CreateMap<ManufacturerGetDTO, ManufacturerEntity>();
            CreateMap<MovementHistoryGetDTO, MovementHistoryEntity>();
            CreateMap<PricesGetDTO, PricesEntity>();
            CreateMap<ProductCategoryGetDTO, ProductCategoryEntity>();
            CreateMap<ProductTypeGetDTO, ProductTypeEntity>();
            CreateMap<ProductUnitGetDTO, ProductUnitEntity>();
            CreateMap<ShipmentGetDTO, ShipmentEntity>();
            CreateMap<SupplierGetDTO, SupplierEntity>();
            CreateMap<BuyerGetDTO, BuyerEntity>();
            CreateMap<WarehouseEmployeeGetDTO, WarehouseEmployeeEntity>();

            // чтение из базы
            CreateMap<BuyerEntity, BuyerPostDTO>();
            CreateMap<CounterpartyEntity, CounterpartyPostDTO>();
            CreateMap<CounterpartyTypeEntity, CounterpartyTypePostDTO>();
            CreateMap<DocumentEntity, DocumentPostDTO>();
            CreateMap<DocumentTypeEntity, DocumentTypePostDTO>();
            CreateMap<JobTitleEntity, JobTitlePostDTO>();
            CreateMap<LegalEntityEntity, LegalEntityPostDTO>();
            CreateMap<LegalFormEntity, LegalFormPostDTO>();
            CreateMap<ManufacturerEntity, ManufacturerPostDTO>();
            CreateMap<MovementHistoryEntity, MovementHistoryPostDTO>();
            CreateMap<PricesEntity, PricesPostDTO>();
            CreateMap<ProductCategoryEntity, ProductCategoryPostDTO>();
            CreateMap<ProductTypeEntity, ProductTypePostDTO>();
            CreateMap<ProductUnitEntity, ProductUnitPostDTO>();
            CreateMap<ShipmentEntity, ShipmentPostDTO>();
            CreateMap<SupplierEntity, SupplierPostDTO>();
            CreateMap<BuyerEntity, BuyerPostDTO>();
            CreateMap<WarehouseEmployeeEntity, WarehouseEmployeePostDTO>();

            // для сверки отгрузок, на всякий
            CreateMap<ShipmentPostDTO, MovementHistoryPostDTO>().ReverseMap();
            CreateMap<ShipmentGetDTO, MovementHistoryGetDTO>().ReverseMap();
        }
    }
}
