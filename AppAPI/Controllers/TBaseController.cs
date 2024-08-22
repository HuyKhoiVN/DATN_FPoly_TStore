using AppAPI.Service;
using AppData.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBaseController<T> : ControllerBase where T : class
    {
        IBaseServices<T> _baseServices;

        public TBaseController(IBaseServices<T> baseServices)
        {
            _baseServices = baseServices;
        }

        #region Methods
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>
        /// 200 - có dữ liệu
        /// 400 - có lỗi nghiệp vụ
        /// 500 - có exception
        /// </returns>
        /// Creatd by: Khoi (22/08/24)
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _baseServices.GetAllAsync();
                return Ok(data);
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException
                };
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// Lấy entity theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpGet("{entityId}")]
        public async Task<IActionResult> GetById(Guid entityId)
        {
            try
            {
                var data = await _baseServices.GetByIdAsync(entityId);
                return Ok(data);
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException
                };
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// Thêm entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T entity)
        {
            try
            {
                var data = await _baseServices.CreateAsync(entity);
                return StatusCode(201, data);
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = entity
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException
                };
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpPut("{entityId}")]
        public async Task<IActionResult> Put([FromRoute] Guid entityId, [FromBody] T entity)
        {
            try
            {
                var data = await _baseServices.UpdateAsync(entityId, entity);
                return Ok(data);
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = entity
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException
                };
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpDelete("{entityId}")]
        public async Task<IActionResult> Delete(Guid entityId)
        {
            try
            {
                var data = await _baseServices.DeleteAsync(entityId);
                return Ok(data);
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException
                };
                return StatusCode(500, response);
            }
        }

        #endregion
    }
}
