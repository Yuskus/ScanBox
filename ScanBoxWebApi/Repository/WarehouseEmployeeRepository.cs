using AutoMapper;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class WarehouseEmployeeRepository : ICrudMethodRepository<WarehouseEmployeeGetDTO, WarehouseEmployeePostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public WarehouseEmployeeRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(WarehouseEmployeePostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WarehouseEmployeeGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(WarehouseEmployeeGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
