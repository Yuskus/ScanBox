п»їusing AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class BuyerRepository : ICrudMethodRepository<BuyerGetDTO, BuyerPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

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

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BuyerGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(BuyerPostDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
