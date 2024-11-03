using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ScanBoxWebApi.Repository
{
    public class ShipmentRepository : ICrudMethodRepository<ShipmentGetDTO, ShipmentPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ShipmentRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int Create(ShipmentPostDTO shipmentDto)
        {
            var shipmentEntity = _context.Shipments.FirstOrDefault(x => x.DocumentId == shipmentDto.DocumentId);

            if (shipmentEntity is null)
            {
                shipmentEntity = _mapper.Map<ShipmentEntity>(shipmentDto);
                _context.Add(shipmentEntity);
                _context.SaveChanges();
                _cache.Remove("shipments");
            }
            return shipmentEntity.Id;
        }

        public int Delete(int shipmentId)
        {
            var shipmentEntity = _context.Shipments.FirstOrDefault(x => x.Id == shipmentId);

            int result = -1;
            if (shipmentEntity is not null)
            {
                result = shipmentEntity.Id;
                _context.Remove(shipmentEntity);
                _context.SaveChanges();
                _cache.Remove("shipments");
            }
            return result;
        }

        public IEnumerable<ShipmentGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("shipments", out IEnumerable<ShipmentGetDTO>? shipments))
            {
                if (shipments is not null) return shipments;
            }
            var shipmentEntity = _context.Shipments.Select(x => _mapper.Map<ShipmentGetDTO>(x)).ToList();
            _cache.Set("", shipmentEntity, TimeSpan.FromMinutes(30));
            return shipmentEntity;
        }

        public int Update(ShipmentGetDTO shipmentDto)
        {
            var shipmentEntity = _context.Shipments.FirstOrDefault(x => x.Id == shipmentDto.Id);

            if (shipmentEntity is not null)
            {
                shipmentEntity.DocumentId = shipmentDto.DocumentId;
                shipmentEntity.ProductUnitId = shipmentDto.ProductUnitId;

                _context.SaveChanges();
                _cache.Remove("shipments");
                return shipmentEntity.Id;
            }
            return -1;
        }
    }
}
