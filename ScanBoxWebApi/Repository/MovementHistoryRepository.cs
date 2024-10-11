using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class MovementHistoryRepository : ICrudMethodRepository<MovementHistoryGetDTO, MovementHistoryPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public MovementHistoryRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(MovementHistoryPostDTO movementHistoryDto)
        {
            var movementHistoryEntity = _context.MovementHistory.FirstOrDefault(x => x.DocumentId == movementHistoryDto.DocumentId);
            if (movementHistoryEntity is null)
            {
                movementHistoryEntity = _mapper.Map<MovementHistoryEntity>(movementHistoryDto);
                _context.Add(movementHistoryEntity);
                _context.SaveChanges();
            }
            return movementHistoryEntity.Id;
        }

        public int Delete(int movementHistoryId)
        {
            var movementHistoryEntity = _context.MovementHistory.FirstOrDefault(x => x.Id == movementHistoryId);
            if (movementHistoryEntity is not null)
            {
                _context.Remove(movementHistoryEntity);
                _context.SaveChanges();
                return movementHistoryEntity.Id;
            }
            return -1;
        }

        public IEnumerable<MovementHistoryGetDTO> GetElemetsList()
        {
            var movementHistoryEntity = _context.MovementHistory.Select(x => _mapper.Map<MovementHistoryGetDTO>(x));
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
                return movementHistoryEntity.Id;
            }
            return -1;
        }
    }
}
