using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ProductTypeRepository : ICrudMethodRepository<ProductTypeGetDTO, ProductTypePostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public ProductTypeRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(ProductTypePostDTO productTypeDto)
        {
            var productTypeEntity = _context.ProductTypes.FirstOrDefault(x => x.Barcode.Equals(productTypeDto.Barcode));
            if (productTypeEntity is null)
            {
                productTypeEntity = _mapper.Map<ProductTypeEntity>(productTypeDto);
                _context.Add(productTypeEntity);
                _context.SaveChanges();
            }
            return productTypeEntity.Id;
        }

        public int Delete(int productTypeId)
        {
            var productTypeEntity = _context.ProductTypes.FirstOrDefault(x => x.Id == productTypeId);

            int result = -1;
            if (productTypeEntity is not null)
            {
                result = productTypeEntity.Id;
                _context.Remove(productTypeEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<ProductTypeGetDTO> GetElemetsList()
        {
            var productTypeEntity = _context.ProductTypes.Select(x => _mapper.Map<ProductTypeGetDTO>(x));
            return productTypeEntity;
        }

        public int Update(ProductTypeGetDTO productTypeDto)
        {
            var productTypeEntity = _context.ProductTypes.FirstOrDefault(x => x.Id == productTypeDto.Id);

            if (productTypeEntity is not null)
            {
                productTypeEntity.Barcode = productTypeDto.Barcode;
                productTypeEntity.ProductName = productTypeDto.ProductName;
                productTypeEntity.Length = productTypeDto.Length;
                productTypeEntity.Heigth = productTypeDto.Heigth;
                productTypeEntity.Width = productTypeDto.Width;
                productTypeEntity.CategoryId = productTypeDto.CategoryId;
                productTypeEntity.ManufacturerId = productTypeDto.ManufacturerId;
                productTypeEntity.ProductPriceId = productTypeDto.ProductPriceId;

                _context.SaveChanges();
                return productTypeEntity.Id;
            }
            return -1;
        }
    }
}
