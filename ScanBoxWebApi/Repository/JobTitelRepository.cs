using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class JobTitelRepository : ICrudMethodRepository<JobTitelGetDTO, JobTitelPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public JobTitelRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(JobTitelPostDTO jobTitelDto)
        {
            var jobTitelEntity = _context.JobTitles.FirstOrDefault(x => x.Name == jobTitelDto.Name);
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
            if (jobTitelEntity != null)
            {
                _context.Remove(jobTitelEntity);
                _context.SaveChanges();
                return jobTitelEntity.Id;
            }
            return -1;
        }

        public IEnumerable<JobTitelGetDTO> GetElemetsList()
        {
            var jobTitelEntity = _context.JobTitles.Select(x => _mapper.Map<JobTitelGetDTO>(x));
            return jobTitelEntity;
        }

        public int Update(JobTitelGetDTO jobTitelDto)
        {
            var jobTitelEntity = _context.JobTitles.FirstOrDefault(x => x.Id == jobTitelDto.Id);
            if (jobTitelEntity != null)
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
