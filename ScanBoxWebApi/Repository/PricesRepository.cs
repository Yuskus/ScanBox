using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class PricesRepository : ICrudMethodRepository<PricesGetDTO, PricesPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public PricesRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(PricesPostDTO pricesDto)
        {
            var pricesEntity = _context.PricesList.FirstOrDefault(x => x.ProductTypeId == pricesDto.ProductTypeId);
            if (pricesEntity is null)
            {
                pricesEntity = _mapper.Map<PricesEntity>(pricesDto);
                _context.Add(pricesEntity);
                _context.SaveChanges();
            }
            return pricesEntity.ProductTypeId;
        }

        public int Delete(int productTypeId)
        {
            var pricesEntity = _context.PricesList.FirstOrDefault(x => x.ProductTypeId == productTypeId);

            int result = -1;
            if (pricesEntity is not null)
            {
                result = pricesEntity.ProductTypeId;
                _context.Remove(pricesEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<PricesGetDTO> GetElemetsList()
        {
            var pricesEntity = _context.PricesList.Select(x => _mapper.Map<PricesGetDTO>(x));
            return pricesEntity;
        }

        public int Update(PricesGetDTO pricesDto)
        {
            var pricesEntity = _context.PricesList.FirstOrDefault(x => x.ProductTypeId == pricesDto.ProductTypeId);

            if (pricesEntity is not null)
            {
                pricesEntity.MinPrice = pricesDto.MinPrice;
                pricesEntity.RetailPrice = pricesDto.RetailPrice;
                pricesEntity.WholesalePrice = pricesDto.WholesalePrice;

                _context.SaveChanges();
                return pricesEntity.ProductTypeId;
            }
            return -1;
        }
    }
}
