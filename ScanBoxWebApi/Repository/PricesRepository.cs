using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class PricesRepository : ICrudMethodRepository<PricesGetDTO, PricesPostDTO>
    {
        public int Create(PricesPostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PricesGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(PricesGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
