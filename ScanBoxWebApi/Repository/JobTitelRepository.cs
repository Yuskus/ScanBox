using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class JobTitelRepository : IJobTitelRepository
    {
        public int AddJobTitel(JobTitelPostDTO jobTitelPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobTitelGetDTO> GetJobTitels()
        {
            throw new NotImplementedException();
        }

        public int PutJobTitel(JobTitelPostDTO jobTitelPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
