using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class WarehouseEmployeeRepository : ICrudMethodRepository<WarehouseEmployeeGetDTO, WarehouseEmployeePostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public WarehouseEmployeeRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(WarehouseEmployeePostDTO warehouseEployeeDto)
        {
            var warehouseEmployeeEntity = _context.WarehouseEmployees.FirstOrDefault(x => x.Phone.Equals(warehouseEployeeDto.Phone));

            if (warehouseEmployeeEntity is null)
            {
                warehouseEmployeeEntity = _mapper.Map<WarehouseEmployeeEntity>(warehouseEployeeDto);
                _context.Add(warehouseEmployeeEntity);
                _context.SaveChanges();
            }
            return warehouseEmployeeEntity.Id;
        }

        public int Delete(int warehouseEployeeId)
        {
            var warehouseEmployeeEntity = _context.WarehouseEmployees.FirstOrDefault(x => x.Id == warehouseEployeeId);

            int result = -1;
            if (warehouseEmployeeEntity is not null)
            {
                result = warehouseEmployeeEntity.Id;
                _context.Remove(warehouseEmployeeEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<WarehouseEmployeeGetDTO> GetElemetsList()
        {
            var warehouseEmployeeEntity = _context.WarehouseEmployees.Select(x => _mapper.Map<WarehouseEmployeeGetDTO>(x)).ToList();
            return warehouseEmployeeEntity;
        }

        public int Update(WarehouseEmployeeGetDTO warehouseEployeeDto)
        {
            var warehouseEmployeeEntity = _context.WarehouseEmployees.FirstOrDefault(x => x.Id == warehouseEployeeDto.Id);

            if (warehouseEmployeeEntity is not null)
            {
                warehouseEmployeeEntity.JobTitleId = warehouseEployeeDto.JobTitleId;
                warehouseEmployeeEntity.Surname = warehouseEployeeDto.Surname;
                warehouseEmployeeEntity.Name = warehouseEployeeDto.Name;
                warehouseEmployeeEntity.Patronymic = warehouseEployeeDto.Patronymic;
                warehouseEmployeeEntity.Birthday = warehouseEployeeDto.Birthday;
                warehouseEmployeeEntity.HireDate = warehouseEployeeDto.HireDate;
                warehouseEmployeeEntity.Address = warehouseEployeeDto.Address;
                warehouseEmployeeEntity.Phone = warehouseEployeeDto.Phone;
                    
                _context.SaveChanges();
                return warehouseEmployeeEntity.Id;
            }
            return -1;
        }
    }
}
