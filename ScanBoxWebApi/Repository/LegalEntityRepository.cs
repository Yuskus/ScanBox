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
    public class LegalEntityRepository : ICrudMethodRepository<LegalEntityGetDTO, LegalEntityPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public LegalEntityRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<int> Create(LegalEntityPostDTO legalEntityDto)
        {
            var legalEntityEntity = await _context.LegalEntities.FirstOrDefaultAsync(x => x.INN.Equals(legalEntityDto.INN));
            if (legalEntityEntity == null)
            {
                legalEntityEntity = _mapper.Map<LegalEntityEntity>(legalEntityDto);
                await _context.AddAsync(legalEntityEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("legal_entities");
            }
            return legalEntityEntity.Id;
        }

        public async Task<int> Delete(int legalEntityId)
        {
            var legalEntityEntity = await _context.LegalEntities.FirstOrDefaultAsync(x => x.Id == legalEntityId);
            int result = -1;
            if (legalEntityEntity is not null)
            {
                result = legalEntityEntity.Id;
                _context.Remove(legalEntityEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("legal_entities");
            }
            return result;
        }

        public async Task<IEnumerable<LegalEntityGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("legal_entities", out IEnumerable<LegalEntityGetDTO>? legalEntities))
            {
                if (legalEntities is not null) return legalEntities;
            }
            var legalEntityEntity = await _context.LegalEntities.Select(x => _mapper.Map<LegalEntityGetDTO>(x)).ToListAsync();
            _cache.Set("legal_entities", legalEntityEntity, TimeSpan.FromMinutes(30));
            return legalEntityEntity;
        }

        public async Task<int> Update(LegalEntityGetDTO legalEntityDto)
        {
            var legalEntityEntity = await _context.LegalEntities.FirstOrDefaultAsync(x => x.Id == legalEntityDto.Id);
            if (legalEntityEntity is not null)
            {
                legalEntityEntity.CounterpartyId = legalEntityDto.CounterpartyId;
                legalEntityEntity.LegalFormId = legalEntityDto.LegalFormId;
                legalEntityEntity.NameOfLegalEntity = legalEntityDto.NameOfLegalEntity;
                legalEntityEntity.DirectorsSurname = legalEntityDto.DirectorsSurname;
                legalEntityEntity.DirectorsName = legalEntityDto.DirectorsName;
                legalEntityEntity.DirectorsPatronymic = legalEntityDto.DirectorsPatronymic;
                legalEntityEntity.INN = legalEntityDto.INN;
                legalEntityEntity.KPP = legalEntityDto.KPP;
                legalEntityEntity.OGRN = legalEntityDto.OGRN;
                legalEntityEntity.LegalAddress = legalEntityDto.LegalAddress;
                legalEntityEntity.ContactPerson = legalEntityDto.ContactPerson;

                await _context.SaveChangesAsync();
                _cache.Remove("legal_entities");
                return legalEntityEntity.Id;
            }
            return -1;
        }
    }
}
