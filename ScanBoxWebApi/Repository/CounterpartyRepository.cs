using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class CounterpartyRepository : ICrudMethodRepository<CounterpartyGetDTO, CounterpartyPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public CounterpartyRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;            
        }

        public int Create(CounterpartyPostDTO counterpartyDto)
        {
            var counterpartyEntity = _mapper.Map<CounterpartyEntity>(counterpartyDto);
            _context.Add(counterpartyEntity);
            _context.SaveChanges();
            return counterpartyEntity.Id;
        }

        public int Delete(int counterpartyId)
        {
            var counterpartyEntity = _context.Counterparties.FirstOrDefault(x => x.Id == counterpartyId);

            if (counterpartyEntity != null)
            {
                _context.Remove(counterpartyEntity);
                _context.SaveChanges();
                return counterpartyEntity.Id;
            }
            return -1;
        }

        public IEnumerable<CounterpartyGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(CounterpartyPostDTO counterpartyDto)
        {
            throw new NotImplementedException();
        }
    }
}
