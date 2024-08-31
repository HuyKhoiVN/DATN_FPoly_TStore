using AppAPI.DtoModels;
using AppAPI.Repositories.EntityInterface;
using AppAPI.Service.EntityInterface;
using AppData.Context;
using AppData.Exceptions;
using AppData.Models;

namespace AppAPI.Service.EntityServices
{
    /// <summary>
    /// Service cho việc mua hàng
    /// BuyProduct - Mua hàng trực tiếp khi chọn sản phẩm
    /// ByProductsFromCart - Mua hàng từ cart
    /// </summary>
    /// Created by Khoi: 27/08/24
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IBillRepository _billRepository;
        private readonly IBillDetailRepository _billDetailRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICartDetailRepository _cartDetailRepository;
        private readonly TStoreDb _dbContext;

        public PurchaseService(IProductRepository productRepository, IProductDetailRepository productDetailRepository,
                               IBillRepository billRepository, IBillDetailRepository billDetailRepository,
                               ICartRepository cartRepository, ICartDetailRepository cartDetailRepository,
                               TStoreDb dbContext)
        {
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
            _billRepository = billRepository;
            _billDetailRepository = billDetailRepository;
            _cartRepository = cartRepository;
            _cartDetailRepository = cartDetailRepository;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Mua hàng trực tiếp khi chọn sản phẩm
        /// </summary>
        /// <param name="purchaseRequestDto">Dto mua hàng với các thông tin cần thiết</param>
        /// <returns>Trả về BillDto gồm các thông tin để hiển thị</returns>
        public async Task<BillDto> BuyProduct(PurchaseRequestDto purchaseRequestDto)
        {
            // 1. Sử dụng transaction để tránh dispose khi chưa hoàn thiện, mọi thứ sẽ được rollback
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Xử lý null khi không có Items (productDetail và quantity)
                    if (purchaseRequestDto.Items == null || purchaseRequestDto.Items.Count == 0)
                    {
                        throw new ValidateException("[From Request Model] Items not found or there isn't any item");
                    }

                    // 2. Tạo mới 1 Bill
                    var bill = new Bill
                    {
                        Id = Guid.NewGuid(),
                        Code = _billRepository.GenerateBillCode(), // Tự sinh code random số 6 chữ số k trùng {hd:D6}
                        IdAccount = purchaseRequestDto.AccountId,
                        IdPaymentMethod = purchaseRequestDto.PaymentMethodId,
                        ShipFee = 20000, // Cố định phí ship
                        PhoneNumber = purchaseRequestDto.PhoneNumber,
                        Address = purchaseRequestDto.Address,
                        CreatedDate = DateTime.UtcNow,
                        BillStatus = AppData.Enum.EnumBillStatus.Pending, // Admin xử lý trạng thái, nếu có thể sẽ làm thêm tự động xử lý sau khi pay
                        BillDetails = new List<BillDetail>() // Khởi tạo BillDetails để đảm bảo k null
                    };                

                    // 3. Duyệt từng phần tử của Items
                    foreach(var item in purchaseRequestDto.Items)
                    {
                        // Lấy ra productDetail theo Id
                        var productDetail = await _productDetailRepository.GetByIdAsync(item.ProductDetailId);
                        if(productDetail == null) // Validate not null
                        {
                            throw new ValidateException($"[From Request Model] ProductDetail not found, id = {item.ProductDetailId}");
                        }

                        // Lấy ra product theo IdProduct của productDetail ở trên
                        var product = await _productRepository.GetByIdAsync(productDetail.IdProduct);
                        if(product == null) // Validate not null
                        {
                            throw new ValidateException($"[From Request Model] Product not found, idProduct = {productDetail.IdProduct}");
                        }

                        // Validate quantity
                        if(item.Quantity <= 0)
                        {
                            throw new ValidateException($"[From Request Model] Quantity must be greater than 0, Id: {productDetail.IdProduct}");
                        }

                        // 4. Tạo mới billDetail cho mỗi phần tử
                        var billDetail = new BillDetail
                        {
                            Id = Guid.NewGuid() ,
                            IdProductDetail = item.ProductDetailId,
                            IdBill = bill.Id,
                            Amount = item.Quantity,
                            Price = product.Price,
                            Discount = 0,
                            Status = true
                        };

                        // 5. Thêm billDetail vào bill đã tạo ở trên
                        bill.BillDetails.Add(billDetail);
                        /*await _billDetailRepository.CreateAsync(billDetail);*/ // 6. Tạo billDetail trong DB - thử nghiệm có thể k cần thiết

                        // 7. Cập nhật quantity của productDetail
                        productDetail.Quantity -= item.Quantity;
                        await _productDetailRepository.UpdateAsync(productDetail.Id, productDetail);
                    }

                    // 8. Tạo bill trong DB
                    await _billRepository.CreateAsync(bill);
                    await transaction.CommitAsync(); // 9. Commit transaction khi mọi thứ hoàn tất

                    // 10. Chuyển từ bill sang BillDto để hiển thị
                    var billDto = ReturnBillDto(bill);
                    return billDto;
                }
                catch
                {
                    // Xử lý Rollback khi có lỗi (vd mất kết nối, lỗi db ..)
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        /// <summary>
        /// Mua hàng từ giỏ hàng (tất cả sp)
        /// </summary>
        /// <param name="purchaseRequestDto">Dto mua hàng nhưng không có Detail</param>
        /// <returns>Trả về BillDto gồm các thông tin để hiển thị</returns>
        public async Task<BillDto> BuyProductsFromCart(PurchaseRequestDto purchaseRequestDto)
        {
            using(var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Lấy ra đầy đủ thông tin Cart theo accountId, bao gồm CartDetails
                    var cart = await _cartRepository.GetCartDetailsByAccountIdAsync(purchaseRequestDto.AccountId);

                    // Xử lý null với CartDetails của cart
                    if (cart.CartDetails == null || cart.CartDetails.Count == 0)
                    {
                        throw new ValidateException($"[From Request Body Cart] CartItems not found or there isn't any item");
                    }

                    // Tạo bill mới
                    var bill = new Bill
                    {
                        Id = Guid.NewGuid(),
                        Code = _billRepository.GenerateBillCode(),
                        IdAccount = purchaseRequestDto.AccountId,
                        IdPaymentMethod = purchaseRequestDto.PaymentMethodId,
                        ShipFee = 20000,
                        PhoneNumber = purchaseRequestDto.PhoneNumber,
                        Address = purchaseRequestDto.Address,
                        CreatedDate = DateTime.UtcNow,
                        BillStatus = AppData.Enum.EnumBillStatus.Pending,
                        BillDetails = new List<BillDetail>()
                    };

                    // Duyệt từng phần tử trong CartDetails
                    foreach (var item in cart.CartDetails)
                    {
                        // Lấy ra productDetail
                        var productDetail = await _productDetailRepository.GetByIdAsync(item.IdProductDetail);
                        if (productDetail == null)
                        {
                            throw new ValidateException($"[From Request Model] ProductDetail not found, id = {item.IdProductDetail}");
                        }

                        // Lấy ra product của productDetail
                        var product = await _productRepository.GetByIdAsync(productDetail.IdProduct);
                        if (product == null)
                        {
                            throw new ValidateException($"[From Request Model] Product not found, idProduct = {productDetail.IdProduct}");
                        }

                        // Validate quantity
                        if (item.ProductQuantity <= 0)
                        {
                            throw new ValidateException($"[From Request Model] Quantity must be greater than 0, Id: {productDetail.IdProduct}");
                        }

                        // Với mỗi productDetail, tạo mới 1 billDetail
                        var billDetail = new BillDetail
                        {
                            Id = Guid.NewGuid(),
                            IdProductDetail = item.IdProductDetail,
                            IdBill = bill.Id,
                            Amount = item.ProductQuantity,
                            Price = item.SalePrice,
                            Discount = (item.OriginalPrice - item.SalePrice),
                            Status = true
                        };
                        bill.BillDetails.Add(billDetail); // Thêm BillDetail vào bill
                        await _billDetailRepository.CreateAsync(billDetail); // Tạo billDetail trong DB

                        // Cập nhật lại quantity của productDetail và update item trong db
                        productDetail.Quantity -= item.ProductQuantity;
                        await _productDetailRepository.UpdateAsync(productDetail.Id, productDetail);
                    }
                    // Tạo bill trong db
                    await _billRepository.CreateAsync(bill);

                    // Duyệt từng phần tử trong CartDetails và xoá
                    foreach (var item in cart.CartDetails)
                    {
                        await _cartDetailRepository.DeleteAsync(item.Id);
                    }

                    // Clear CartDetails trong bộ nhớ và update lại cart trong db
                    cart.CartDetails.Clear();
                    await _cartRepository.UpdateAsync(cart.Id, cart);

                    // Commit khi hoàn tất
                    await transaction.CommitAsync();

                    // Trả về Dto
                    return ReturnBillDto(bill);
                }
                catch
                {
                    // Rollback nếu có lỗi
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        /// <summary>
        /// Mapping Bill sang BillDto
        /// </summary>
        /// <param name="bill">Bill chi tiết gồm có BillDetails ở trong</param>
        /// <returns>Dto để hiển thị</returns>
        /// <exception cref="ValidateException">throw VlaidateEx nếu BillDetails null</exception>
        private BillDto ReturnBillDto(Bill bill)
        {
            if(bill.BillDetails == null || bill.BillDetails.Count == 0)
            {
                throw new ValidateException("Error Exception: The BillDetails of the Bill is null, so we can't convert to Dto");  
            }
            var billDto = new BillDto
            {
                Id = bill.Id,
                Code = bill.Code,
                IdAccount = bill.IdAccount,
                IdPaymentMethod = bill.IdPaymentMethod,
                ShipFee = bill.ShipFee,
                PhoneNumber = bill.PhoneNumber,
                Address = bill.Address,
                CreatedDate = bill.CreatedDate,
                BillStatus = bill.BillStatus,
                TotalMoney = bill.BillDetails.Sum(bd => bd.Price * bd.Amount),
                MoneyReduce = bill.BillDetails.Sum(bd => bd.Discount),
                BillDetails = bill.BillDetails.Select(bd => new BillDetailDto
                {
                    Id = bd.Id,
                    IdProductDetail = bd.IdProductDetail,
                    Amount = bd.Amount,
                    Price = bd.Price,
                    Discount = bd.Discount,
                }).ToList(),
            };
            return billDto;
        }
    }
}
