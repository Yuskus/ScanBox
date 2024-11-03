using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ScanBoxWebApi.Repository
{
    public class SupplierRepository : ICrudMethodRepository<SupplierGetDTO, SupplierPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public SupplierRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int Create(SupplierPostDTO supplierDto)
        {
            var supplierEntity = _context.Suppilers.FirstOrDefault(x => x.CounterpartyId == supplierDto.CounterpartyId);

            if (supplierEntity is null)
            {
                supplierEntity = _mapper.Map<SupplierEntity>(supplierDto);
                _context.Add(supplierEntity);
                _context.SaveChanges();
                _cache.Remove("suppilers");
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
                _cache.Remove("suppilers");
            }
            return result;
        }

        public IEnumerable<SupplierGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("suppilers", out IEnumerable<SupplierGetDTO>? suppilers))
            {
                if (suppilers is not null) return suppilers;
            }
            var supplierEntity = _context.Suppilers.Select(x => _mapper.Map<SupplierGetDTO>(x)).ToList();
            _cache.Set("suppilers", supplierEntity, TimeSpan.FromMinutes(30));
            return supplierEntity;
        }

        public int Update(SupplierGetDTO supplierDto)
        {
            var supplierEntity = _context.Suppilers.FirstOrDefault(x => x.Id == supplierDto.Id);

            if (supplierEntity is not null)
            {
                supplierEntity.CounterpartyId = supplierDto.CounterpartyId;

                _context.SaveChanges();
                _cache.Remove("suppilers");
                return supplierEntity.Id;
            }
            return -1;
        }
    }
}
