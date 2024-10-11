using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class LegalFormRepository : ICrudMethodRepository<LegalFormGetDTO, LegalFormPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public LegalFormRepository( ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(LegalFormPostDTO legalFormDto)
        {
            var legalFormEntity = _context.LegalForms.FirstOrDefault(x => x.LegalFormName == legalFormDto.LegalFormName);
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
            if (legalFormEntity != null)
            {
                _context.Remove(legalFormEntity);
                _context.SaveChanges();
                return legalFormEntity.Id;
            }
            return -1;
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
