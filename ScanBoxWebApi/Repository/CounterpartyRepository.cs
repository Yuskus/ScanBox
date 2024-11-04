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
    public class CounterpartyRepository : ICrudMethodRepository<CounterpartyGetDTO, CounterpartyPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public CounterpartyRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<int> Create(CounterpartyPostDTO counterpartyDto)
        {
            var counterpartyEntity = _mapper.Map<CounterpartyEntity>(counterpartyDto);
            await _context.AddAsync(counterpartyEntity);
            await _context.SaveChangesAsync();
            _cache.Remove("counterparties");
            return counterpartyEntity.Id;
        }

        public async Task<int> Delete(int counterpartyId)
        {
            var counterpartyEntity = await _context.Counterparties.FirstOrDefaultAsync(x => x.Id == counterpartyId);
            int result = -1;
            if (counterpartyEntity is not null)
            {
                result = counterpartyEntity.Id;
                _context.Remove(counterpartyEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("counterparties");
            }
            return result;
        }

        public async Task<IEnumerable<CounterpartyGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("counterparties", out IEnumerable<CounterpartyGetDTO>? counterparties))
            {
                if (counterparties is not null) return counterparties;
            }
            var counterpartyEntity = await _context.Counterparties.Select(x => _mapper.Map<CounterpartyGetDTO>(x)).ToListAsync();
            _cache.Set("counterparties", counterpartyEntity, TimeSpan.FromMinutes(30));
            return counterpartyEntity;
        }

        public async Task<int> Update(CounterpartyGetDTO counterpartyDto)
        {
            var counterpartyEntity = await _context.Counterparties.FirstOrDefaultAsync(x => x.Id == counterpartyDto.Id);

            if (counterpartyEntity is not null)
            {
                counterpartyEntity.CounterpartyTypeId = counterpartyDto.CounterpartyTypeId;
                counterpartyEntity.Address = counterpartyDto.Address;
                counterpartyEntity.Phone = counterpartyDto.Phone;
                counterpartyEntity.Email = counterpartyDto.Email;

                await _context.SaveChangesAsync();
                _cache.Remove("counterparties");
                return counterpartyEntity.Id;
            }
            return -1;
        }
    }
}
