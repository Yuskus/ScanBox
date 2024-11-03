using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ScanBoxWebApi.Repository
{
    public class WarehouseEmployeeRepository : ICrudMethodRepository<WarehouseEmployeeGetDTO, WarehouseEmployeePostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public WarehouseEmployeeRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int Create(WarehouseEmployeePostDTO warehouseEployeeDto)
        {
            var warehouseEmployeeEntity = _context.WarehouseEmployees.FirstOrDefault(x => x.Phone.Equals(warehouseEployeeDto.Phone));

            if (warehouseEmployeeEntity is null)
            {
                warehouseEmployeeEntity = _mapper.Map<WarehouseEmployeeEntity>(warehouseEployeeDto);
                _context.Add(warehouseEmployeeEntity);
                _context.SaveChanges();
                _cache.Remove("warehouse_employees");
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
                _cache.Remove("warehouse_employees");
            }
            return result;
        }

        public IEnumerable<WarehouseEmployeeGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("warehouse_employees", out IEnumerable<WarehouseEmployeeGetDTO>? warehouseEmployees))
            {
                if (warehouseEmployees is not null) return warehouseEmployees;
            }
            var warehouseEmployeeEntity = _context.WarehouseEmployees.Select(x => _mapper.Map<WarehouseEmployeeGetDTO>(x)).ToList();
            _cache.Set("warehouse_employees", warehouseEmployeeEntity, TimeSpan.FromMinutes(30));
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
                _cache.Remove("warehouse_employees");
                return warehouseEmployeeEntity.Id;
            }
            return -1;
        }
    }
}
