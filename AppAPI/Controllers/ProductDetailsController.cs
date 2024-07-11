using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        ICRUDApi<ProductDetail> _crud;
        TStoreDb _context = new TStoreDb();

        public ProductDetailsController()
        {
            CRUDApi<ProductDetail> crud = new CRUDApi<ProductDetail>(_context, _context.ProductDetails);
            _crud = crud;
        }
        [HttpGet("get-all-productdetail")]
        public IEnumerable<ProductDetail> GetProductDetails()
        {
            return _crud.GetAllItems().ToList();
        }
        [HttpGet("get-ProductDetail-byIdproduct")]
        public IEnumerable<ProductDetail> GetProductDetailByProductId(Guid idProduct)
        {
            var productDetail = _context.ProductDetails.Where(b => b.IdProduct == idProduct);
            return productDetail.ToList();
        }
        public bool CreateProductDetail(Guid idSize, Guid idColor, Guid idProductCategory, Guid idProducer, Guid idProduct, decimal Price,
            int Quantity, string Rating, string Name, string Description, DateTime CreatedDate, DateTime ModifiledDate, bool Status)
        {
            var prddt = new ProductDetail();
            prddt.Id = new Guid();
            prddt.IdProduct = idProduct;
            prddt.Product = _context.Products.FirstOrDefault(p => p.Id == idProduct);
            prddt.IdSize = idSize;
            prddt.Size = _context.Sizes.FirstOrDefault(p => p.Id == idSize);
            prddt.IdColor = idColor;
            prddt.Color = _context.Colors.FirstOrDefault(p => p.Id == idColor);
            prddt.IdProductCategory = idProductCategory;
            prddt.ProductCatergory = _context.ProductCatergories.FirstOrDefault(p => p.Id == idProductCategory);
            prddt.IdProducer = idProducer;
            prddt.Producer = _context.Producers.FirstOrDefault(p => p.Id == idProducer);
            prddt.Price = Price;
            prddt.Quantity = Quantity;
            prddt.Rating = Rating;
            prddt.Name = Name;
            prddt.Description = Description;
            prddt.CreatedDate = CreatedDate;
            prddt.ModifiledDate = ModifiledDate;
            prddt.Status = true;

            return _crud.CreateItem(prddt);

        }
        [HttpPut("Update")]
        public bool UpdateProductDetail(Guid id, Guid idSize, Guid idColor, Guid idProductCategory, Guid idProducer, Guid idProduct, decimal Price,
            int Quantity, string Rating, string Name, string Description, DateTime CreatedDate, DateTime ModifiledDate, bool Status)
        {
            var prddt = _context.ProductDetails.FirstOrDefault(p => p.Id == id);
            if (prddt != null)
            {
                prddt.IdProduct = idProduct;
                prddt.Product = _context.Products.FirstOrDefault(p => p.Id == idProduct);
                prddt.IdSize = idSize;
                prddt.Size = _context.Sizes.FirstOrDefault(p => p.Id == idSize);
                prddt.IdColor = idColor;
                prddt.Color = _context.Colors.FirstOrDefault(p => p.Id == idColor);
                prddt.IdProductCategory = idProductCategory;
                prddt.ProductCatergory = _context.ProductCatergories.FirstOrDefault(p => p.Id == idProductCategory);
                prddt.IdProducer = idProducer;
                prddt.Producer = _context.Producers.FirstOrDefault(p => p.Id == idProducer);
                prddt.Price = Price;
                prddt.Quantity = Quantity;
                prddt.Rating = Rating;
                prddt.Name = Name;
                prddt.Description = Description;
                prddt.CreatedDate = CreatedDate;
                prddt.ModifiledDate = ModifiledDate;
                prddt.Status = true;
                return _crud.UpdateItem(prddt);
            }
            return false;
        }
        [HttpDelete("delete-prdDetail")]
        public bool DeleteProductDetail(Guid id)
        {
            var productDetail = _context.ProductDetails.FirstOrDefault(b => b.Id == id);
            if (productDetail != null)
            {
                return _crud.DeleteItem(productDetail);

            }
            return false;
        }
    }
}
