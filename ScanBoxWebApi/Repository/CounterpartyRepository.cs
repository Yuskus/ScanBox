using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

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

        public int Create(CounterpartyPostDTO counterpartyDto)
        {
            var counterpartyEntity = _mapper.Map<CounterpartyEntity>(counterpartyDto);
            _context.Add(counterpartyEntity);
            _context.SaveChanges();
            _cache.Remove("counterparties");
            return counterpartyEntity.Id;
        }

        public int Delete(int counterpartyId)
        {
            var counterpartyEntity = _context.Counterparties.FirstOrDefault(x => x.Id == counterpartyId);
            int result = -1;
            if (counterpartyEntity is not null)
            {
                result = counterpartyEntity.Id;
                _context.Remove(counterpartyEntity);
                _context.SaveChanges();
                _cache.Remove("counterparties");
            }
            return result;
        }

        public IEnumerable<CounterpartyGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("counterparties", out IEnumerable<CounterpartyGetDTO>? counterparties))
            {
                if (counterparties is not null) return counterparties;
            }
            var counterpartyEntity = _context.Counterparties.Select(x => _mapper.Map<CounterpartyGetDTO>(x)).ToList();
            _cache.Set("counterparties", counterpartyEntity, TimeSpan.FromMinutes(30));
            return counterpartyEntity;
        }

        public int Update(CounterpartyGetDTO counterpartyDto)
        {
            var counterpartyEntity = _context.Counterparties.FirstOrDefault(x => x.Id == counterpartyDto.Id);

            if (counterpartyEntity is not null)
            {
                counterpartyEntity.CounterpartyTypeId = counterpartyDto.CounterpartyTypeId;
                counterpartyEntity.Address = counterpartyDto.Address;
                counterpartyEntity.Phone = counterpartyDto.Phone;
                counterpartyEntity.Email = counterpartyDto.Email;

                _context.SaveChanges();
                _cache.Remove("counterparties");
                return counterpartyEntity.Id;
            }
            return -1;
        }
    }
}
