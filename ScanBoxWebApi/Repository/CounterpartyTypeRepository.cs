using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class CounterpartyTypeRepository : ICrudMethodRepository<CounterpartyTypeGetDTO, CounterpartyTypePostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public CounterpartyTypeRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(CounterpartyTypePostDTO counterpartyTypeDto)
        {
            var counterpartyTypeEntity = _context.CounterpartiesTypes.FirstOrDefault(x => x.TypeName.Equals(counterpartyTypeDto.TypeName));

            if (counterpartyTypeEntity == null)
            {
                counterpartyTypeEntity = _mapper.Map<CounterpartyTypeEntity>(counterpartyTypeDto);
                _context.Add(counterpartyTypeEntity);
                _context.SaveChanges();
                return counterpartyTypeEntity.Id;
            }
            return -1;
        }

        public int Delete(int counterpartyTypeId)
        {
            var counterpartyTypeEntity = _context.CounterpartiesTypes.FirstOrDefault(x =>x.Id == counterpartyTypeId);
            if (counterpartyTypeEntity != null)
            {
                _context.Remove(counterpartyTypeEntity);
                _context.SaveChanges();
                return counterpartyTypeEntity.Id;
            }
            return -1;
        }


        public IEnumerable<CounterpartyTypeGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(CounterpartyTypeGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
