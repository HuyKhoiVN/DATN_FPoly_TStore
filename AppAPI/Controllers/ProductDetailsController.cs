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

        [HttpPost("Create")]

        public bool CreateProductDetail(Guid idSize, Guid idColor, Guid idProductCategory, Guid idProducer, Guid idProduct, decimal price,
            int quantity, string rating, string name, string description)
        {
            var prddt = new ProductDetail();

            prddt.Id = new Guid();
            prddt.IdProduct = idProduct;
            prddt.IdSize = idSize;
            prddt.IdColor = idColor;
            prddt.IdProductCategory = idProductCategory;
            prddt.IdProducer = idProducer;
            prddt.Price = price;
            prddt.Quantity = quantity;
            prddt.Rating = rating;
            prddt.Name = name;
            prddt.Description = description;
            prddt.CreatedDate = DateTime.Now;
            prddt.ModifiledDate = DateTime.Now;
            prddt.Status = true;

            return _crud.CreateItem(prddt);

        }
        [HttpPut("Update")]
        public bool UpdateProductDetail( Guid id,Guid idSize, Guid idColor, Guid idProductCategory, Guid idProducer, Guid idProduct, decimal price,
            int quantity, string rating, string name, string description)
        {
            var prddt = _context.ProductDetails.FirstOrDefault(p => p.Id == id);
            if (prddt != null)
            {
                prddt.IdProduct = idProduct;
                prddt.IdSize = idSize;
                prddt.IdColor = idColor;
                prddt.IdProductCategory = idProductCategory;
                prddt.IdProducer = idProducer;
                prddt.Price = price;
                prddt.Quantity = quantity;
                prddt.Rating = rating;
                prddt.Name = name;
                prddt.Description = description;
                prddt.ModifiledDate= DateTime.Now;
 
                return _crud.UpdateItem(prddt);
            }
            return false;
        }
        [HttpPut("soft-DeleteProductDetail")]
        public bool DeleteProductDetail(Guid id)
        {
            var productDetail = _context.ProductDetails.FirstOrDefault(x => x .Id == id);
            if (productDetail != null)
            { 
                productDetail.Status = false;
                return _crud.UpdateItem(productDetail);
            }
            return false;
        }
    }
}
