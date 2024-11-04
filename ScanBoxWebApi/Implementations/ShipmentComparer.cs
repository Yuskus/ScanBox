using AutoMapper;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ScanBoxWebApi.Implementations
{
    public class ShipmentComparer : IShipmentComparer
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public ShipmentComparer(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Compare(int documentId)
        {
            int ship = await _context.Shipments.CountAsync(x => x.DocumentId == documentId);
            int moves = await _context.MovementHistory.CountAsync(x => x.DocumentId == documentId);
            return ship - moves;
        }

        public async Task<IEnumerable<ShipmentGetDTO>> GetMissingUnits(int documentId)
        {
            var shipment = GetShipment(documentId);
            var history = GetHistory(documentId);

            return await shipment.Except(history).ToListAsync();
        }

        public async Task<IEnumerable<ShipmentGetDTO>> GetUnwantedUnits(int documentId)
        {
            var shipment = GetShipment(documentId);
            var history = GetHistory(documentId);

            return await history.Except(shipment).ToListAsync();
        }

        public async Task<IEnumerable<ShipmentGetDTO>> GetFoundUnits(int documentId)
        {
            var shipment = GetShipment(documentId);
            var history = GetHistory(documentId);

            return await history.Intersect(shipment).ToListAsync();
        }

        private IQueryable<ShipmentGetDTO> GetShipment(int documentId)
        {
            var shipment = _context.Shipments.Where(x => x.DocumentId == documentId)
                                             .Select(x => _mapper.Map<ShipmentGetDTO>(x));

            if (!shipment.Any()) throw new ArgumentException($"{documentId} the list does not contain any elements");

            return shipment;
        }

        private IQueryable<ShipmentGetDTO> GetHistory(int documentId)
        {
            return _context.MovementHistory.Where(x => x.DocumentId == documentId).Select(x => _mapper.Map<ShipmentGetDTO>(x));
        }
    }
}
