using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ShipmentRepository : ICrudMethodRepository<ShipmentGetDTO, ShipmentPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public ShipmentRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(ShipmentPostDTO shipmentDto)
        {
            var shipmentEntity = _context.Shipments.FirstOrDefault(x => x.DocumentId == shipmentDto.DocumentId);

            if (shipmentEntity is null)
            {
                shipmentEntity = _mapper.Map<ShipmentEntity>(shipmentDto);
                _context.Add(shipmentEntity);
                _context.SaveChanges();
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
            }
            return result;
        }

        public IEnumerable<ShipmentGetDTO> GetElemetsList()
        {
            var shipmentEntity = _context.Shipments.Select(x => _mapper.Map<ShipmentGetDTO>(x));
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
                return shipmentEntity.Id;
            }
            return -1;
        }
    }
}
