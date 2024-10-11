using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IJobTitleRepository : IDeleteRepository
    {
        public int AddJobTitel(JobTitlePostDTO jobTitelPostDTO);
        public int PutJobTitel(JobTitlePostDTO jobTitelPutDTO);
        public IEnumerable<JobTitleGetDTO> GetJobTitels();  
    }
}
