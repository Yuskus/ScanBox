using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

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
        public async Task<int> Create(ProductCategoryPostDTO productGategoryDto)
        {
            var productCategoryEntity = await _context.ProductCategories.FirstOrDefaultAsync(x => x.CategoryName.ToLower() == productGategoryDto.CategoryName.ToLower());
            if (productCategoryEntity is null)
            {
                productCategoryEntity = _mapper.Map<ProductCategoryEntity>(productGategoryDto);
                await _context.AddAsync(productCategoryEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("product_categories");
            }
            return productCategoryEntity.Id;
        }

        public async Task<int> Delete(int productCategoryId)
        {
            var productCategoryEntity = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategoryId);

            int result = -1;
            if (productCategoryEntity is not null)
            {
                result = productCategoryEntity.Id;
                _context.Remove(productCategoryEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("product_categories");
            }
            return result;
        }

        public async Task<IEnumerable<ProductCategoryGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("product_categories", out IEnumerable<ProductCategoryGetDTO>? productCategories))
            {
                if (productCategories is not null) return productCategories;
            }
            var productCategoryEntity = await _context.ProductCategories.Select(x => _mapper.Map<ProductCategoryGetDTO>(x)).ToListAsync();
            _cache.Set("product_categories", productCategoryEntity, TimeSpan.FromMinutes(30));
            return productCategoryEntity;
        }

        public async Task<int> Update(ProductCategoryGetDTO productGategoryDto)
        {
            var productCategoryEntity = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == productGategoryDto.Id);

            if (productCategoryEntity is not null)
            {
                productCategoryEntity.CategoryName = productGategoryDto.CategoryName;
                productCategoryEntity.Description = productGategoryDto.Description;

                await _context.SaveChangesAsync();
                _cache.Remove("product_categories");
                return productCategoryEntity.Id;
            }
            return -1;
        }
    }
}
