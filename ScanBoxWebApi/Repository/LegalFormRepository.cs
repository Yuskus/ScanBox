using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class LegalFormRepository : ICrudMethodRepository<LegalFormGetDTO, LegalFormPostDTO>
    {
        public int Create(LegalFormPostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LegalFormGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(LegalFormGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
