using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class IndividualRepositoty : ICrudMethodRepository<IndividualGetDTO, IndividualPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public IndividualRepositoty(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(IndividualPostDTO individualDto)
        {
            var individualEntity = _context.Individuals.FirstOrDefault(x => x.CounterpartyId == individualDto.CounterpartyId);
            if (individualEntity == null)
            {
                individualEntity = _mapper.Map<IndividualEntity>(individualDto);
                _context.Add(individualEntity);
                _context.SaveChanges();
            }
            return individualEntity.Id;
        }

        public int Delete(int individualId)
        {
            var individualEntity = _context.Individuals.FirstOrDefault(x => x.Id == individualId);

            int result = -1;
            if (individualEntity is not null)
            {
                result = individualEntity.Id;
                _context.Remove(individualEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<IndividualGetDTO> GetElemetsList()
        {
            var individualEntity = _context.Individuals.Select(x => _mapper.Map<IndividualGetDTO>(x));
            return individualEntity;
        }

        public int Update(IndividualGetDTO individualDto)
        {
            var individualEntity = _context.Individuals.FirstOrDefault(x => x.Id == individualDto.Id);
            
            if (individualEntity != null)
            {
                individualEntity.CounterpartyId = individualDto.CounterpartyId;
                individualEntity.Surname = individualDto.Surname;
                individualEntity.Name = individualDto.Name;
                individualEntity.Patronymic = individualDto.Patronymic;

                _context.SaveChanges();
                return individualEntity.Id;
            }
            return -1;
        }
    }
}
