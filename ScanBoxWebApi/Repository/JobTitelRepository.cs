using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class JobTitelRepository : ICrudMethodRepository<JobTitleGetDTO, JobTitlePostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public JobTitelRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(JobTitlePostDTO jobTitelDto)
        {
            var jobTitelEntity = _context.JobTitles.FirstOrDefault(x => x.Name.Equals(jobTitelDto.Name, StringComparison.InvariantCultureIgnoreCase));
            if (jobTitelEntity == null)
            {
                jobTitelEntity = _mapper.Map<JobTitleEntity>(jobTitelDto);
                _context.Add(jobTitelEntity);
                _context.SaveChanges();
            }
            return jobTitelEntity.Id;
        }

        public int Delete(int jobTitelId)
        {
            var jobTitelEntity = _context.JobTitles.FirstOrDefault(x => x.Id == jobTitelId);
            int result = -1;
            if (jobTitelEntity is not null)
            {
                result = jobTitelEntity.Id;
                _context.Remove(jobTitelEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<JobTitleGetDTO> GetElemetsList()
        {
            var jobTitelEntity = _context.JobTitles.Select(x => _mapper.Map<JobTitleGetDTO>(x)).ToList();
            return jobTitelEntity;
        }

        public int Update(JobTitleGetDTO jobTitelDto)
        {
            var jobTitelEntity = _context.JobTitles.FirstOrDefault(x => x.Id == jobTitelDto.Id);
            if (jobTitelEntity is not null)
            {
                jobTitelEntity.Name = jobTitelDto.Name;
                jobTitelEntity.DutiesDescription = jobTitelDto.DutiesDescription;
                jobTitelEntity.BaseSalary = jobTitelDto.BaseSalary;                

                _context.SaveChanges();
                return jobTitelEntity.Id;
            }
            return -1;
        }
    }
}
