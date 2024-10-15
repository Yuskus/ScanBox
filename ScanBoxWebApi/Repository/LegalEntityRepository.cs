using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class LegalEntityRepository : ICrudMethodRepository<LegalEntityGetDTO, LegalEntityPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public LegalEntityRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(LegalEntityPostDTO legalEntityDto)
        {
            var legalEntityEntity = _context.LegalEntities.FirstOrDefault(x => x.INN.Equals(legalEntityDto.INN));
            if (legalEntityEntity == null)
            {
                legalEntityEntity = _mapper.Map<LegalEntityEntity>(legalEntityDto);
                _context.Add(legalEntityEntity);
                _context.SaveChanges();
            }
            return legalEntityEntity.Id;
        }

        public int Delete(int legalEntityId)
        {
            var legalEntityEntity = _context.LegalEntities.FirstOrDefault(x => x.Id == legalEntityId);
            int result = -1;
            if (legalEntityEntity is not null)
            {
                result = legalEntityEntity.Id;
                _context.Remove(legalEntityEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<LegalEntityGetDTO> GetElemetsList()
        {
            var legalEntityEntity = _context.LegalEntities.Select(x => _mapper.Map<LegalEntityGetDTO>(x));
            return legalEntityEntity;
        }

        public int Update(LegalEntityGetDTO legalEntityDto)
        {
            var legalEntityEntity = _context.LegalEntities.FirstOrDefault(x => x.Id == legalEntityDto.Id);
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

                _context.SaveChanges();
                return legalEntityEntity.Id;
            }
            return -1;
        }
    }
}
