using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class BuyerRepository : ICrudMethodRepository<BuyerGetDTO, BuyerPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public BuyerRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(BuyerPostDTO buyerDTO)
        {
            var buyerEntity = _context.Buyers.FirstOrDefault(x => x.CounterpartyId == buyerDTO.CounterpartyId);

            if (buyerEntity == null)
            {
                buyerEntity = _mapper.Map<BuyerEntity>(buyerDTO);
                _context.Add(buyerEntity);
                _context.SaveChanges();
            }
            return buyerEntity.Id;
        }

        public int Delete(int buyerId)
        {
            var buyerEntity = _context.Buyers.FirstOrDefault(x => x.Id == buyerId);
            int result = -1;
            if (buyerEntity is not null)
            {
                result = buyerEntity.Id;
                _context.Remove(buyerEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<BuyerGetDTO> GetElemetsList()
        {
            var buyerEntities = _context.Buyers.Select(x => _mapper.Map<BuyerGetDTO>(x)).ToList();
            return buyerEntities;
        }

        public int Update(BuyerGetDTO buyerDto)
        {
            var buyerEntity = _context.Buyers.FirstOrDefault(x => x.Id == buyerDto.Id);
            if (buyerEntity is not null)
            {
                buyerEntity.CounterpartyId = buyerDto.CounterpartyId;
                _context.SaveChanges();
                return buyerEntity.Id;
            }
            return -1;
        }
    }
}
