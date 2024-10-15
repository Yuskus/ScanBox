using AutoMapper;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Implementations
{
    public class ShipmentComparer : IShipmentComparer<ShipmentGetDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public ShipmentComparer(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Compare(int documentId)
        {
            return _context.Shipments.Count(x => x.DocumentId == documentId) - _context.MovementHistory.Count(x => x.DocumentId == documentId);
        }

        public IEnumerable<ShipmentGetDTO> GetMissingUnits(int documentId)
        {
            var shipment = GetShipment(documentId);
            var history = GetHistory(documentId);

            return [.. shipment.Except(history) ];
        }

        public IEnumerable<ShipmentGetDTO> GetUnwantedUnits(int documentId)
        {
            var shipment = GetShipment(documentId);
            var history = GetHistory(documentId);

            return [.. history.Except(shipment)];
        }

        public IEnumerable<ShipmentGetDTO> GetFoundUnits(int documentId)
        {
            var shipment = GetShipment(documentId);
            var history = GetHistory(documentId);

            return [.. history.Intersect(shipment)];
        }

        private IQueryable<ShipmentGetDTO> GetShipment(int documentId)
        {
            var shipment = _context.Shipments.Where(x => x.DocumentId == documentId)
                                             .Select(x => _mapper.Map<ShipmentGetDTO>(x));

            return shipment.Any() ? shipment : throw new ArgumentException($"{documentId} the list does not contain any elements");
        }

        private IQueryable<ShipmentGetDTO> GetHistory(int documentId)
        {
            return _context.MovementHistory.Where(x => x.DocumentId == documentId).Select(x => _mapper.Map<ShipmentGetDTO>(x));
        }
    }
}
