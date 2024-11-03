using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ScanBoxWebApi.Repository
{
    public class MovementHistoryRepository : ICrudMethodRepository<MovementHistoryGetDTO, MovementHistoryPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public MovementHistoryRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int Create(MovementHistoryPostDTO movementHistoryDto)
        {
            var movementHistoryEntity = _context.MovementHistory.FirstOrDefault(x => x.DocumentId == movementHistoryDto.DocumentId);
            if (movementHistoryEntity is null)
            {
                movementHistoryEntity = _mapper.Map<MovementHistoryEntity>(movementHistoryDto);
                _context.Add(movementHistoryEntity);
                _context.SaveChanges();
                _cache.Remove("movement_history");
            }
            return movementHistoryEntity.Id;
        }

        public int Delete(int movementHistoryId)
        {
            var movementHistoryEntity = _context.MovementHistory.FirstOrDefault(x => x.Id == movementHistoryId);

            int result = -1;
            if (movementHistoryEntity is not null)
            {
                result = movementHistoryEntity.Id;
                _context.Remove(movementHistoryEntity);
                _context.SaveChanges();
                _cache.Remove("movement_history");
            }
            return result;
        }

        public IEnumerable<MovementHistoryGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("movement_history", out IEnumerable<MovementHistoryGetDTO>? movementHistory))
            {
                if (movementHistory is not null) return movementHistory;
            }
            var movementHistoryEntity = _context.MovementHistory.Select(x => _mapper.Map<MovementHistoryGetDTO>(x)).ToList();
            _cache.Set("movement_history", movementHistoryEntity, TimeSpan.FromMinutes(30));
            return movementHistoryEntity;
        }

        public int Update(MovementHistoryGetDTO movementHistoryDto)
        {
            var movementHistoryEntity = _context.MovementHistory.FirstOrDefault(x => x.Id == movementHistoryDto.Id);

            if (movementHistoryEntity is not null)
            {
                movementHistoryEntity.DocumentId = movementHistoryDto.DocumentId;
                movementHistoryEntity.ProductUnitId = movementHistoryDto.ProductUnitId;

                _context.SaveChanges();
                _cache.Remove("movement_history");
                return movementHistoryEntity.Id;
            }
            return -1;
        }
    }
}
