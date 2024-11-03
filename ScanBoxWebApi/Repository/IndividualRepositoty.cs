using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ScanBoxWebApi.Repository
{
    public class IndividualRepositoty : ICrudMethodRepository<IndividualGetDTO, IndividualPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public IndividualRepositoty (ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int Create(IndividualPostDTO individualDto)
        {
            var individualEntity = _context.Individuals.FirstOrDefault(x => x.CounterpartyId == individualDto.CounterpartyId);
            if (individualEntity == null)
            {
                individualEntity = _mapper.Map<IndividualEntity>(individualDto);
                _context.Add(individualEntity);
                _context.SaveChanges();
                _cache.Remove("individuals");
            }
            return individualEntity.Id;
        }

        public int Delete(int individualId)
        {
            var individualEntity = _context.Individuals.FirstOrDefault(x => x.Id == individualId);
            int result = -1;
            if (individualEntity is not null)
            {
                result = individualEntity.Id;
                _context.Remove(individualEntity);
                _context.SaveChanges();
                _cache.Remove("individuals");
            }
            return result;
        }

        public IEnumerable<IndividualGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("individuals", out IEnumerable<IndividualGetDTO>? individuals))
            {
                if (individuals is not null) return individuals;
            }
            var individualEntity = _context.Individuals.Select(x => _mapper.Map<IndividualGetDTO>(x)).ToList();
            _cache.Set("individuals", individualEntity, TimeSpan.FromMinutes(30));
            return individualEntity;
        }

        public int Update(IndividualGetDTO individualDto)
        {
            var individualEntity = _context.Individuals.FirstOrDefault(x => x.Id == individualDto.Id);
            if (individualEntity is not null)
            {
                individualEntity.CounterpartyId = individualDto.CounterpartyId;
                individualEntity.Surname = individualDto.Surname;
                individualEntity.Name = individualDto.Name;
                individualEntity.Patronymic = individualDto.Patronymic;

                _context.SaveChanges();
                _cache.Remove("individuals");
                return individualEntity.Id;
            }
            return -1;
        }
    }
}
