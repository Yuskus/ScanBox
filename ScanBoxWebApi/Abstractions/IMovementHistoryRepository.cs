using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IMovementHistoryRepository : IRepository
    {
        public int AddMovementHistory(MovementHistoryPostDTO movementHistoryPostDTO);
        public int PutMovementHistory(MovementHistoryPostDTO movementHistoryPuttDTO);
        public int DelMovementHistory(int movementHistoryId);
        public IEnumerable<MovementHistoryGetDTO> GetMovementHistory();
    }
}
