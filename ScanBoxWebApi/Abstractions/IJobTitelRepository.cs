using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IJobTitelRepository : IDeleteRepository
    {
        public int AddJobTitel(JobTitelPostDTO jobTitelPostDTO);
        public int PutJobTitel(JobTitelPostDTO jobTitelPutDTO);
        public int DelJobTitel(int jobTitelId);
        public IEnumerable<JobTitelGetDTO> GetJobTitels();  
    }
}
