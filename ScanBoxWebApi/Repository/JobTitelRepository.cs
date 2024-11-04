using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

namespace ScanBoxWebApi.Repository
{
    public class JobTitelRepository : ICrudMethodRepository<JobTitleGetDTO, JobTitlePostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public JobTitelRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<int> Create(JobTitlePostDTO jobTitelDto)
        {
            var jobTitelEntity = await _context.JobTitles.FirstOrDefaultAsync(x => x.Name.ToLower() == jobTitelDto.Name.ToLower());
            if (jobTitelEntity == null)
            {
                jobTitelEntity = _mapper.Map<JobTitleEntity>(jobTitelDto);
                await _context.AddAsync(jobTitelEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("job_titles");
            }
            return jobTitelEntity.Id;
        }

        public async Task<int> Delete(int jobTitelId)
        {
            var jobTitelEntity = await _context.JobTitles.FirstOrDefaultAsync(x => x.Id == jobTitelId);
            int result = -1;
            if (jobTitelEntity is not null)
            {
                result = jobTitelEntity.Id;
                _context.Remove(jobTitelEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("job_titles");
            }
            return result;
        }

        public async Task<IEnumerable<JobTitleGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("job_titles", out IEnumerable<JobTitleGetDTO>? jobTitles))
            {
                if (jobTitles is not null) return jobTitles;
            }
            var jobTitelEntity = await _context.JobTitles.Select(x => _mapper.Map<JobTitleGetDTO>(x)).ToListAsync();
            _cache.Set("job_titles", jobTitelEntity, TimeSpan.FromMinutes(30));
            return jobTitelEntity;
        }

        public async Task<int> Update(JobTitleGetDTO jobTitelDto)
        {
            var jobTitelEntity = await _context.JobTitles.FirstOrDefaultAsync(x => x.Id == jobTitelDto.Id);
            if (jobTitelEntity is not null)
            {
                jobTitelEntity.Name = jobTitelDto.Name;
                jobTitelEntity.DutiesDescription = jobTitelDto.DutiesDescription;
                jobTitelEntity.BaseSalary = jobTitelDto.BaseSalary;                

                await _context.SaveChangesAsync();
                _cache.Remove("job_titles");
                return jobTitelEntity.Id;
            }
            return -1;
        }
    }
}
