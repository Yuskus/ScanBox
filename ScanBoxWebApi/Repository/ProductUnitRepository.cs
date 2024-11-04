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
    public class ProductUnitRepository : ICrudMethodRepository<ProductUnitGetDTO, ProductUnitPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ProductUnitRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<int> Create(ProductUnitPostDTO productUnitDto)
        {
            var productUnitEntity = await _context.ProductUnits.FirstOrDefaultAsync(x => x.UniqueBarcode.Equals(productUnitDto.UniqueBarcode));
            if (productUnitEntity is null)
            {
                productUnitEntity = _mapper.Map<ProductUnitEntity>(productUnitDto);
                await _context.AddAsync(productUnitEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("product_units");
            }
            return productUnitEntity.Id;
        }

        public async Task<int> Delete(int productUnitId)
        {
            var productUnitEntity = await _context.ProductUnits.FirstOrDefaultAsync(x => x.Id == productUnitId);

            int result = -1;
            if (productUnitEntity is not null)
            {
                result = productUnitEntity.Id;
                _context.Remove(productUnitEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("product_units");
            }
            return result;
        }

        public async Task<IEnumerable<ProductUnitGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("product_units", out IEnumerable<ProductUnitGetDTO>? productUnits))
            {
                if (productUnits is not null) return productUnits;
            }
            var productUnitEntity = await _context.ProductUnits.Select(x => _mapper.Map<ProductUnitGetDTO>(x)).ToListAsync();
            _cache.Set("product_units", productUnitEntity, TimeSpan.FromMinutes(30));
            return productUnitEntity;
        }

        public async Task<int> Update(ProductUnitGetDTO productUnitDto)
        {
            var productUnitEntity = await _context.ProductUnits.FirstOrDefaultAsync(x => x.Id == productUnitDto.Id);

            if (productUnitEntity is not null)
            {
                productUnitEntity.UniqueBarcode = productUnitDto.UniqueBarcode;
                productUnitEntity.ProductionDate = productUnitDto.ProductionDate;
                productUnitEntity.RealizationPrice = productUnitDto.RealizationPrice;
                productUnitEntity.ProductTypeId = productUnitDto.ProductTypeId;
                productUnitEntity.SupplierId = productUnitDto.SupplierId;

                await _context.SaveChangesAsync();
                _cache.Remove("product_units");
                return productUnitEntity.Id;
            }
            return -1;
        }
    }
}
