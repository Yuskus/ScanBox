using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IJobTitelRepository : IDeleteRepository
    {
        public int AddJobTitel(JobTitelPostDTO jobTitelPostDTO);
        public int PutJobTitel(JobTitelPostDTO jobTitelPutDTO);
        public IEnumerable<JobTitelGetDTO> GetJobTitels();  
    }
}
