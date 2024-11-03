using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ScanBoxWebApi.Repository
{
    public class ManufacturerRepository : ICrudMethodRepository<ManufacturerGetDTO, ManufacturerPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ManufacturerRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int Create(ManufacturerPostDTO manufacturerDto)
        {
            var manufacturerEntity = _context.Manufacturers.FirstOrDefault(x => x.CounterpartyId == manufacturerDto.CounterpartyId);
            if (manufacturerEntity == null)
            {
                manufacturerEntity = _mapper.Map<ManufacturerEntity>(manufacturerDto);
                _context.Add(manufacturerEntity);
                _context.SaveChanges();
                _cache.Remove("manufacturers");
            }
            return manufacturerEntity.Id;
        }

        public int Delete(int manufacturerId)
        {
            var manufacturerEntity = _context.Manufacturers.FirstOrDefault(x => x.Id == manufacturerId);

            int result = -1;
            if (manufacturerEntity is not null)
            {
                result = manufacturerEntity.Id;
                _context.Remove(manufacturerEntity);
                _context.SaveChanges();
                _cache.Remove("manufacturers");
            }
            return result;
        }

        public IEnumerable<ManufacturerGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("manufacturers", out IEnumerable<ManufacturerGetDTO>? manufacturers))
            {
                if (manufacturers is not null) return manufacturers;
            }
            var manufacturerEntity = _context.Manufacturers.Select(x => _mapper.Map<ManufacturerGetDTO>(x)).ToList();
            _cache.Set("manufacturers", manufacturerEntity, TimeSpan.FromMinutes(30));
            return manufacturerEntity;
        }

        public int Update(ManufacturerGetDTO manufacturerDto)
        {
            var manufacturerEntity = _context.Manufacturers.FirstOrDefault(x => x.Id == manufacturerDto.Id);
            if (manufacturerEntity != null)
            {
                manufacturerEntity.CounterpartyId = manufacturerDto.CounterpartyId;

                _context.SaveChanges();
                _cache.Remove("manufacturers");
                return manufacturerEntity.Id;
            }
            return -1;
        }
    }
}
