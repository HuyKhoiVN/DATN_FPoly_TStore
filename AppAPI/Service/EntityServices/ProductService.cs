using AppAPI.DtoModels;
using AppAPI.Repositories;
using AppAPI.Repositories.EntityInterface;
using AppAPI.Service.EntityInterface;
using AppData.Models;

namespace AppAPI.Service.EntityServices
{
    public class ProductService : BaseServices<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IBaseRepository<Product> repository, IProductRepository productRepository) : base(repository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDetailDto?> GetProductDetailInfo(Guid productId)
        {
            var product = await _productRepository.GetProductDetailInfo(productId);

            if (product == null) return null;

            var productDto = new ProductDetailDto
            {
                Name = product.Name,
                Images = product.Images?.Select(img => img.ImageUrl).ToList(),
                Rating = product.Rating,
                Price = product.Price,
                Description = product.Description,
                Details = product.ProductDetails?.Select(pd => new ProductDetailInfoDto
                {
                    SizeName = pd.Size?.SizeName,
                    ColorName = pd.Color?.ColorName,
                    Quantity = pd.Quantity
                }).ToList()
            };
            return productDto;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            var data = await _productRepository.GetProductByCategoryId(categoryId);
            return data;
        }
    }
}
