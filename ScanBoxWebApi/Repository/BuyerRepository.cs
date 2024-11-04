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
    public class BuyerRepository : ICrudMethodRepository<BuyerGetDTO, BuyerPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public BuyerRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<int> Create(BuyerPostDTO buyerDTO)
        {
            var buyerEntity = await _context.Buyers.FirstOrDefaultAsync(x => x.CounterpartyId == buyerDTO.CounterpartyId);

            if (buyerEntity == null)
            {
                buyerEntity = _mapper.Map<BuyerEntity>(buyerDTO);
                await _context.AddAsync(buyerEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("buyers");
            }
            return buyerEntity.Id;
        }

        public async Task<int> Delete(int buyerId)
        {
            var buyerEntity = await _context.Buyers.FirstOrDefaultAsync(x => x.Id == buyerId);
            int result = -1;
            if (buyerEntity is not null)
            {
                result = buyerEntity.Id;
                _context.Remove(buyerEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("buyers");
            }
            return result;
        }

        public async Task<IEnumerable<BuyerGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("buyers", out IEnumerable<BuyerGetDTO>? buyers))
            {
                if (buyers is not null) return buyers;
            }
            var buyerEntities = await _context.Buyers.Select(x => _mapper.Map<BuyerGetDTO>(x)).ToListAsync();
            _cache.Set("buyers", buyerEntities, TimeSpan.FromMinutes(30));
            return buyerEntities;
        }

        public async Task<int> Update(BuyerGetDTO buyerDto)
        {
            var buyerEntity = await _context.Buyers.FirstOrDefaultAsync(x => x.Id == buyerDto.Id);
            if (buyerEntity is not null)
            {
                buyerEntity.CounterpartyId = buyerDto.CounterpartyId;
                await _context.SaveChangesAsync();
                _cache.Remove("buyers");
                return buyerEntity.Id;
            }
            return -1;
        }
    }
}
