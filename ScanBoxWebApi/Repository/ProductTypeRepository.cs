using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ScanBoxWebApi.Repository
{
    public class ProductTypeRepository : ICrudMethodRepository<ProductTypeGetDTO, ProductTypePostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ProductTypeRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int Create(ProductTypePostDTO productTypeDto)
        {
            var productTypeEntity = _context.ProductTypes.FirstOrDefault(x => x.Barcode.Equals(productTypeDto.Barcode));
            if (productTypeEntity is null)
            {
                productTypeEntity = _mapper.Map<ProductTypeEntity>(productTypeDto);
                _context.Add(productTypeEntity);
                _context.SaveChanges();
                _cache.Remove("product_types");
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
                _cache.Remove("product_types");
            }
            return result;
        }

        public IEnumerable<ProductTypeGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("product_types", out IEnumerable<ProductTypeGetDTO>? productTypes))
            {
                if (productTypes is not null) return productTypes;
            }
            var productTypeEntity = _context.ProductTypes.Select(x => _mapper.Map<ProductTypeGetDTO>(x)).ToList();
            _cache.Set("product_types", productTypeEntity, TimeSpan.FromMinutes(30));
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
                _cache.Remove("product_types");
                return productTypeEntity.Id;
            }
            return -1;
        }
    }
}
