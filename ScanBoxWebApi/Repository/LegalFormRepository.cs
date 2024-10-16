using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class LegalFormRepository : ICrudMethodRepository<LegalFormGetDTO, LegalFormPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        public LegalFormRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(LegalFormPostDTO legalFormDto)
        {
            var legalFormEntity = _context.LegalForms.FirstOrDefault(x => x.LegalFormName.Equals(legalFormDto.LegalFormName));
            if (legalFormEntity == null)
            {
                legalFormEntity = _mapper.Map<LegalFormEntity>(legalFormDto);
                _context.Add(legalFormEntity);
                _context.SaveChanges();
            }
            return legalFormEntity.Id;
        }

        public int Delete(int legalFormId)
        {
            var legalFormEntity = _context.LegalForms.FirstOrDefault(x => x.Id == legalFormId);

            int result = -1;
            if (legalFormEntity is not null)
            {
                result = legalFormEntity.Id;
                _context.Remove(legalFormEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<LegalFormGetDTO> GetElemetsList()
        {
            var legalFormEntity = _context.LegalForms.Select(x => _mapper.Map<LegalFormGetDTO>(x));
            return legalFormEntity;
        }

        public int Update(LegalFormGetDTO legalFormDto)
        {
            var legalFormEntity = _context.LegalForms.FirstOrDefault(x => x.Id == legalFormDto.Id);
            if (legalFormEntity != null)
            {
                legalFormEntity.LegalFormName = legalFormDto.LegalFormName;
                legalFormEntity.Description = legalFormDto.Description;

                _context.SaveChanges();
                return legalFormEntity.Id;
            }
            return -1;
        }
    }
}
