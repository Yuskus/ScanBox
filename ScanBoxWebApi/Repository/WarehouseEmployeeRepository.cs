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
        public async Task<int> Create(WarehouseEmployeePostDTO warehouseEployeeDto)
        {
            var warehouseEmployeeEntity = await _context.WarehouseEmployees.FirstOrDefaultAsync(x => x.Phone.Equals(warehouseEployeeDto.Phone));

            if (warehouseEmployeeEntity is null)
            {
                warehouseEmployeeEntity = _mapper.Map<WarehouseEmployeeEntity>(warehouseEployeeDto);
                await _context.AddAsync(warehouseEmployeeEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("warehouse_employees");
            }
            return warehouseEmployeeEntity.Id;
        }

        public async Task<int> Delete(int warehouseEployeeId)
        {
            var warehouseEmployeeEntity = await _context.WarehouseEmployees.FirstOrDefaultAsync(x => x.Id == warehouseEployeeId);

            int result = -1;
            if (warehouseEmployeeEntity is not null)
            {
                result = warehouseEmployeeEntity.Id;
                _context.Remove(warehouseEmployeeEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("warehouse_employees");
            }
            return result;
        }

        public async Task<IEnumerable<WarehouseEmployeeGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("warehouse_employees", out IEnumerable<WarehouseEmployeeGetDTO>? warehouseEmployees))
            {
                if (warehouseEmployees is not null) return warehouseEmployees;
            }
            var warehouseEmployeeEntity = await _context.WarehouseEmployees.Select(x => _mapper.Map<WarehouseEmployeeGetDTO>(x)).ToListAsync();
            _cache.Set("warehouse_employees", warehouseEmployeeEntity, TimeSpan.FromMinutes(30));
            return warehouseEmployeeEntity;
        }

        public async Task<int> Update(WarehouseEmployeeGetDTO warehouseEployeeDto)
        {
            var warehouseEmployeeEntity = await _context.WarehouseEmployees.FirstOrDefaultAsync(x => x.Id == warehouseEployeeDto.Id);

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
                    
                await _context.SaveChangesAsync();
                _cache.Remove("warehouse_employees");
                return warehouseEmployeeEntity.Id;
            }
            return -1;
        }
    }
}
