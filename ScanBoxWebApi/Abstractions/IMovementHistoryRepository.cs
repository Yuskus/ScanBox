п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IMovementHistoryRepository : IDeleteRepository
    {
        public int AddMovementHistory(MovementHistoryPostDTO movementHistoryPostDTO);
        public int PutMovementHistory(MovementHistoryPostDTO movementHistoryPuttDTO);
        public IEnumerable<MovementHistoryGetDTO> GetMovementHistory();
    }
}
