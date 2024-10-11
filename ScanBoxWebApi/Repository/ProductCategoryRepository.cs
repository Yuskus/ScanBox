using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ProductCategoryRepository : ICrudMethodRepository<ProductCategoryGetDTO, ProductCategoryPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public ProductCategoryRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(ProductCategoryPostDTO productGategoryDto)
        {
            var productCategoryEntity = _context.ProductCategories.FirstOrDefault(x => x.CategoryName.Equals(productGategoryDto.CategoryName,StringComparison.OrdinalIgnoreCase));
            if (productCategoryEntity is null)
            {
                productCategoryEntity = _mapper.Map<ProductCategoryEntity>(productGategoryDto);
                _context.Add(productCategoryEntity);
                _context.SaveChanges();
            }
            return productCategoryEntity.Id;
        }

        public int Delete(int productCategoryId)
        {
            var productCategoryEntity = _context.ProductCategories.FirstOrDefault(x => x.Id == productCategoryId);

            int result = -1;
            if (productCategoryEntity is not null)
            {
                result = productCategoryEntity.Id;
                _context.Remove(productCategoryEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<ProductCategoryGetDTO> GetElemetsList()
        {
            var productCategoryEntity = _context.ProductCategories.Select(x => _mapper.Map<ProductCategoryGetDTO>(x));
            return productCategoryEntity;
        }

        public int Update(ProductCategoryGetDTO productGategoryDto)
        {
            var productCategoryEntity = _context.ProductCategories.FirstOrDefault(x => x.Id == productGategoryDto.Id);

            if (productCategoryEntity is not null)
            {
                productCategoryEntity.CategoryName = productGategoryDto.CategoryName;
                productCategoryEntity.Description = productGategoryDto.Description;

                _context.SaveChanges();
                return productCategoryEntity.Id;
            }
            return -1;
        }
    }
}
