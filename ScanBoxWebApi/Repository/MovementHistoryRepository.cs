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
        public async Task<int> Create(MovementHistoryPostDTO movementHistoryDto)
        {
            var movementHistoryEntity = await _context.MovementHistory.FirstOrDefaultAsync(x => x.DocumentId == movementHistoryDto.DocumentId);
            if (movementHistoryEntity is null)
            {
                movementHistoryEntity = _mapper.Map<MovementHistoryEntity>(movementHistoryDto);
                await _context.AddAsync(movementHistoryEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("movement_history");
            }
            return movementHistoryEntity.Id;
        }

        public async Task<int> Delete(int movementHistoryId)
        {
            var movementHistoryEntity = await _context.MovementHistory.FirstOrDefaultAsync(x => x.Id == movementHistoryId);

            int result = -1;
            if (movementHistoryEntity is not null)
            {
                result = movementHistoryEntity.Id;
                _context.Remove(movementHistoryEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("movement_history");
            }
            return result;
        }

        public async Task<IEnumerable<MovementHistoryGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("movement_history", out IEnumerable<MovementHistoryGetDTO>? movementHistory))
            {
                if (movementHistory is not null) return movementHistory;
            }
            var movementHistoryEntity = await _context.MovementHistory.Select(x => _mapper.Map<MovementHistoryGetDTO>(x)).ToListAsync();
            _cache.Set("movement_history", movementHistoryEntity, TimeSpan.FromMinutes(30));
            return movementHistoryEntity;
        }

        public async Task<int> Update(MovementHistoryGetDTO movementHistoryDto)
        {
            var movementHistoryEntity = await _context.MovementHistory.FirstOrDefaultAsync(x => x.Id == movementHistoryDto.Id);

            if (movementHistoryEntity is not null)
            {
                movementHistoryEntity.DocumentId = movementHistoryDto.DocumentId;
                movementHistoryEntity.ProductUnitId = movementHistoryDto.ProductUnitId;

                await _context.SaveChangesAsync();
                _cache.Remove("movement_history");
                return movementHistoryEntity.Id;
            }
            return -1;
        }
    }
}
