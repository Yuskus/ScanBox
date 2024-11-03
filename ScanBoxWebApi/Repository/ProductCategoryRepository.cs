using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ScanBoxWebApi.Repository
{
    public class ProductCategoryRepository : ICrudMethodRepository<ProductCategoryGetDTO, ProductCategoryPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ProductCategoryRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int Create(ProductCategoryPostDTO productGategoryDto)
        {
            var productCategoryEntity = _context.ProductCategories.FirstOrDefault(x => x.CategoryName.Equals(productGategoryDto.CategoryName, StringComparison.OrdinalIgnoreCase));
            if (productCategoryEntity is null)
            {
                productCategoryEntity = _mapper.Map<ProductCategoryEntity>(productGategoryDto);
                _context.Add(productCategoryEntity);
                _context.SaveChanges();
                _cache.Remove("product_categories");
            }
            return productCategoryEntity.Id;
        }

        public int Delete(int productCategoryId)
        {
            var productCategoryEntity = _context.ProductCategories.FirstOrDefault(x => x.Id == productCategoryId);

            int result = -1;
            if (productCategoryEntity is not null)
            {
                result = productCategoryEntity.Id;
                _context.Remove(productCategoryEntity);
                _context.SaveChanges();
                _cache.Remove("product_categories");
            }
            return result;
        }

        public IEnumerable<ProductCategoryGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("product_categories", out IEnumerable<ProductCategoryGetDTO>? productCategories))
            {
                if (productCategories is not null) return productCategories;
            }
            var productCategoryEntity = _context.ProductCategories.Select(x => _mapper.Map<ProductCategoryGetDTO>(x)).ToList();
            _cache.Set("product_categories", productCategoryEntity, TimeSpan.FromMinutes(30));
            return productCategoryEntity;
        }

        public int Update(ProductCategoryGetDTO productGategoryDto)
        {
            var productCategoryEntity = _context.ProductCategories.FirstOrDefault(x => x.Id == productGategoryDto.Id);

            if (productCategoryEntity is not null)
            {
                productCategoryEntity.CategoryName = productGategoryDto.CategoryName;
                productCategoryEntity.Description = productGategoryDto.Description;

                _context.SaveChanges();
                _cache.Remove("product_categories");
                return productCategoryEntity.Id;
            }
            return -1;
        }
    }
}
