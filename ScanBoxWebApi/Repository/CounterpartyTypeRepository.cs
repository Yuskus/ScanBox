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
    public class CounterpartyTypeRepository : ICrudMethodRepository<CounterpartyTypeGetDTO, CounterpartyTypePostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public CounterpartyTypeRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<int> Create(CounterpartyTypePostDTO counterpartyTypeDto)
        {
            var counterpartyTypeEntity = await _context.CounterpartiesTypes.FirstOrDefaultAsync(x => x.TypeName.Equals(counterpartyTypeDto.TypeName));

            if (counterpartyTypeEntity == null)
            {
                counterpartyTypeEntity = _mapper.Map<CounterpartyTypeEntity>(counterpartyTypeDto);
                await _context.AddAsync(counterpartyTypeEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("counterparty_type");
                return counterpartyTypeEntity.Id;
            }
            return -1;
        }

        public async Task<int> Delete(int counterpartyTypeId)
        {
            var counterpartyTypeEntity = await _context.CounterpartiesTypes.FirstOrDefaultAsync(x => x.Id == counterpartyTypeId);
            int result = -1;
            if (counterpartyTypeEntity is not null)
            {
                result = counterpartyTypeEntity.Id;
                _context.Remove(counterpartyTypeEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("counterparty_type");
            }
            return result;
        }


        public async Task<IEnumerable<CounterpartyTypeGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("counterparty_type", out IEnumerable<CounterpartyTypeGetDTO>? counterpartyType))
            {
                if (counterpartyType is not null) return counterpartyType;
            }
            var counterpartyTypeEntity = await _context.CounterpartiesTypes.Select(x => _mapper.Map<CounterpartyTypeGetDTO>(x)).ToListAsync();
            _cache.Set("", counterpartyTypeEntity, TimeSpan.FromMinutes(30));
            return counterpartyTypeEntity;
        }

        public async Task<int> Update(CounterpartyTypeGetDTO counterpartyTypeDto)
        {
            var counterpartyTypeEntity = await _context.CounterpartiesTypes.FirstOrDefaultAsync(x => x.Id == counterpartyTypeDto.Id);
            if (counterpartyTypeEntity is not null)
            {
                counterpartyTypeEntity.TypeName = counterpartyTypeDto.TypeName;

                await _context.SaveChangesAsync();
                _cache.Remove("counterparty_type");
                return counterpartyTypeEntity.Id;
            }
            return -1;
        }
    }
}
