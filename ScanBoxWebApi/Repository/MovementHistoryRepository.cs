using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class MovementHistoryRepository : ICrudMethodRepository<MovementHistoryGetDTO, MovementHistoryPostDTO>
    {
        public int Create(MovementHistoryPostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovementHistoryGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(MovementHistoryGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
