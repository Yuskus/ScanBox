п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class MovementHistoryRepository : IMovementHistoryRepository
    {
        public int AddMovementHistory(MovementHistoryPostDTO movementHistoryPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovementHistoryGetDTO> GetMovementHistory()
        {
            throw new NotImplementedException();
        }

        public int PutMovementHistory(MovementHistoryPostDTO movementHistoryPuttDTO)
        {
            throw new NotImplementedException();
        }
    }
}
