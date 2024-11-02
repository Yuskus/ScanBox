using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class SupplierRepository : ICrudMethodRepository<SupplierGetDTO, SupplierPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public SupplierRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(SupplierPostDTO supplierDto)
        {
            var supplierEntity = _context.Suppilers.FirstOrDefault(x => x.CounterpartyId == supplierDto.CounterpartyId);

            if (supplierEntity is null)
            {
                supplierEntity = _mapper.Map<SupplierEntity>(supplierDto);
                _context.Add(supplierEntity);
                _context.SaveChanges();
            }
            return supplierEntity.Id;
        }

        public int Delete(int supplierId)
        {
            var supplierEntity = _context.Suppilers.FirstOrDefault(x => x.Id == supplierId);

            int result = -1;
            if (supplierEntity is not null)
            {
                result = supplierEntity.Id;
                _context.Remove(supplierEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<SupplierGetDTO> GetElemetsList()
        {
            var supplierEntity = _context.Suppilers.Select(x => _mapper.Map<SupplierGetDTO>(x)).ToList();
            return supplierEntity;
        }

        public int Update(SupplierGetDTO supplierDto)
        {
            var supplierEntity = _context.Suppilers.FirstOrDefault(x => x.Id == supplierDto.Id);

            if (supplierEntity is not null)
            {
                supplierEntity.CounterpartyId = supplierDto.CounterpartyId;

                _context.SaveChanges();
                return supplierEntity.Id;
            }
            return -1;
        }
    }
}
