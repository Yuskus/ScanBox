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
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

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
            int result = -1;
            if (counterpartyTypeEntity is not null)
            {
                result = counterpartyTypeEntity.Id;
                _context.Remove(counterpartyTypeEntity);
                _context.SaveChanges();
            }
            return result;
        }


        public IEnumerable<CounterpartyTypeGetDTO> GetElemetsList()
        {
            var counterpartyTypeEntity = _context.CounterpartiesTypes.Select(x => _mapper.Map<CounterpartyTypeGetDTO>(x));
            return counterpartyTypeEntity;
        }

        public int Update(CounterpartyTypeGetDTO counterpartyTypeDto)
        {
            var counterpartyTypeEntity = _context.CounterpartiesTypes.FirstOrDefault(x => x.Id == counterpartyTypeDto.Id);
            if (counterpartyTypeEntity is not null)
            {
                counterpartyTypeEntity.TypeName = counterpartyTypeDto.TypeName;

                _context.SaveChanges();
                return counterpartyTypeEntity.Id;
            }
            return -1;
        }
    }
}
