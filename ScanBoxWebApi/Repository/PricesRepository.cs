using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ScanBoxWebApi.Repository
{
    public class PricesRepository : ICrudMethodRepository<PricesGetDTO, PricesPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public PricesRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int Create(PricesPostDTO pricesDto)
        {
            var pricesEntity = _context.PricesList.FirstOrDefault(x => x.ProductTypeId == pricesDto.ProductTypeId);
            if (pricesEntity is null)
            {
                pricesEntity = _mapper.Map<PricesEntity>(pricesDto);
                _context.Add(pricesEntity);
                _context.SaveChanges();
                _cache.Remove("prices");
            }
            return pricesEntity.ProductTypeId;
        }

        public int Delete(int productTypeId)
        {
            var pricesEntity = _context.PricesList.FirstOrDefault(x => x.ProductTypeId == productTypeId);

            int result = -1;
            if (pricesEntity is not null)
            {
                result = pricesEntity.ProductTypeId;
                _context.Remove(pricesEntity);
                _context.SaveChanges();
                _cache.Remove("prices");
            }
            return result;
        }

        public IEnumerable<PricesGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("prices", out IEnumerable<PricesGetDTO>? prices))
            {
                if (prices is not null) return prices;
            }
            var pricesEntity = _context.PricesList.Select(x => _mapper.Map<PricesGetDTO>(x)).ToList();
            _cache.Set("prices", pricesEntity, TimeSpan.FromMinutes(30));
            return pricesEntity;
        }

        public int Update(PricesGetDTO pricesDto)
        {
            var pricesEntity = _context.PricesList.FirstOrDefault(x => x.ProductTypeId == pricesDto.ProductTypeId);

            if (pricesEntity is not null)
            {
                pricesEntity.MinPrice = pricesDto.MinPrice;
                pricesEntity.RetailPrice = pricesDto.RetailPrice;
                pricesEntity.WholesalePrice = pricesDto.WholesalePrice;

                _context.SaveChanges();
                _cache.Remove("prices");
                return pricesEntity.ProductTypeId;
            }
            return -1;
        }
    }
}
