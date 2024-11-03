using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

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

        public int Create(CounterpartyTypePostDTO counterpartyTypeDto)
        {
            var counterpartyTypeEntity = _context.CounterpartiesTypes.FirstOrDefault(x => x.TypeName.Equals(counterpartyTypeDto.TypeName));

            if (counterpartyTypeEntity == null)
            {
                counterpartyTypeEntity = _mapper.Map<CounterpartyTypeEntity>(counterpartyTypeDto);
                _context.Add(counterpartyTypeEntity);
                _context.SaveChanges();
                _cache.Remove("counterparty_type");
                return counterpartyTypeEntity.Id;
            }
            return -1;
        }

        public int Delete(int counterpartyTypeId)
        {
            var counterpartyTypeEntity = _context.CounterpartiesTypes.FirstOrDefault(x =>x.Id == counterpartyTypeId);
            int result = -1;
            if (counterpartyTypeEntity is not null)
            {
                result = counterpartyTypeEntity.Id;
                _context.Remove(counterpartyTypeEntity);
                _context.SaveChanges();
                _cache.Remove("counterparty_type");
            }
            return result;
        }


        public IEnumerable<CounterpartyTypeGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("counterparty_type", out IEnumerable<CounterpartyTypeGetDTO>? counterpartyType))
            {
                if (counterpartyType is not null) return counterpartyType;
            }
            var counterpartyTypeEntity = _context.CounterpartiesTypes.Select(x => _mapper.Map<CounterpartyTypeGetDTO>(x)).ToList();
            _cache.Set("", counterpartyTypeEntity, TimeSpan.FromMinutes(30));
            return counterpartyTypeEntity;
        }

        public int Update(CounterpartyTypeGetDTO counterpartyTypeDto)
        {
            var counterpartyTypeEntity = _context.CounterpartiesTypes.FirstOrDefault(x => x.Id == counterpartyTypeDto.Id);
            if (counterpartyTypeEntity is not null)
            {
                counterpartyTypeEntity.TypeName = counterpartyTypeDto.TypeName;

                _context.SaveChanges();
                _cache.Remove("counterparty_type");
                return counterpartyTypeEntity.Id;
            }
            return -1;
        }
    }
}
