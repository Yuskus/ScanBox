using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ProductUnitRepository : ICrudMethodRepository<ProductUnitGetDTO,ProductUnitPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public ProductUnitRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(ProductUnitPostDTO productUnitDto)
        {
            var productUnitEntity = _context.ProductUnits.FirstOrDefault(x => x.UniqueBarcode.Equals(productUnitDto.UniqueBarcode));
            if (productUnitEntity is null)
            {
                productUnitEntity = _mapper.Map<ProductUnitEntity>(productUnitDto);
                _context.Add(productUnitEntity);
                _context.SaveChanges();
            }
            return productUnitEntity.Id;
        }

        public int Delete(int productUnitId)
        {
            var productUnitEntity = _context.ProductUnits.FirstOrDefault(x => x.Id == productUnitId);

            int result = -1;
            if (productUnitEntity is not null)
            {
                result = productUnitEntity.Id;
                _context.Remove(productUnitEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<ProductUnitGetDTO> GetElemetsList()
        {
            var productUnitEntity = _context.ProductUnits.Select(x => _mapper.Map<ProductUnitGetDTO>(x));
            return productUnitEntity;
        }

        public int Update(ProductUnitGetDTO productUnitDto)
        {
            var productUnitEntity = _context.ProductUnits.FirstOrDefault(x => x.Id == productUnitDto.Id);

            if (productUnitEntity is not null)
            {
                productUnitEntity.UniqueBarcode = productUnitDto.UniqueBarcode;
                productUnitEntity.ProductionDate = productUnitDto.ProductionDate;
                productUnitEntity.RealizationPrice = productUnitDto.RealizationPrice;
                productUnitEntity.ProductTypeId = productUnitDto.ProductTypeId;
                productUnitEntity.SupplierId = productUnitDto.SupplierId;               

                _context.SaveChanges();
                return productUnitEntity.Id;
            }
            return -1;
        }
    }
}
