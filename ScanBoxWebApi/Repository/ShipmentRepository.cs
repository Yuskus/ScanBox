using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

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
        public async Task<int> Create(ShipmentPostDTO shipmentDto)
        {
            var shipmentEntity = await _context.Shipments.FirstOrDefaultAsync(x => x.DocumentId == shipmentDto.DocumentId);

            if (shipmentEntity is null)
            {
                shipmentEntity = _mapper.Map<ShipmentEntity>(shipmentDto);
                await _context.AddAsync(shipmentEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("shipments");
            }
            return shipmentEntity.Id;
        }

        public async Task<int> Delete(int shipmentId)
        {
            var shipmentEntity = await _context.Shipments.FirstOrDefaultAsync(x => x.Id == shipmentId);

            int result = -1;
            if (shipmentEntity is not null)
            {
                result = shipmentEntity.Id;
                _context.Remove(shipmentEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("shipments");
            }
            return result;
        }

        public async Task<IEnumerable<ShipmentGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("shipments", out IEnumerable<ShipmentGetDTO>? shipments))
            {
                if (shipments is not null) return shipments;
            }
            var shipmentEntity = await _context.Shipments.Select(x => _mapper.Map<ShipmentGetDTO>(x)).ToListAsync();
            _cache.Set("", shipmentEntity, TimeSpan.FromMinutes(30));
            return shipmentEntity;
        }

        public async Task<int> Update(ShipmentGetDTO shipmentDto)
        {
            var shipmentEntity = await _context.Shipments.FirstOrDefaultAsync(x => x.Id == shipmentDto.Id);

            if (shipmentEntity is not null)
            {
                shipmentEntity.DocumentId = shipmentDto.DocumentId;
                shipmentEntity.ProductUnitId = shipmentDto.ProductUnitId;

                await _context.SaveChangesAsync();
                _cache.Remove("shipments");
                return shipmentEntity.Id;
            }
            return -1;
        }
    }
}
