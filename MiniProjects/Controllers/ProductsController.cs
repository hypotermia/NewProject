using Microsoft.AspNetCore.Mvc;
using MiniProjects.Interfaces;
using MiniProjects.Models;
using static MiniProjects.Repository.WebApiHelper;

namespace MiniProjects.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost]
        public async Task<ApiResponseObj> InsertUpdateProducts([FromBody] Product product)
        {
            try
            {
                var checkId = await _productRepository.GetTaskByIdAsync(product.Id);
                if(checkId == null)
                {
                    await _productRepository.AddTaskAsync(product);
                }
                else
                {
                    await _productRepository.UpdateTaskAsync(product.Id,product);
                }

                return new ApiResponseObj
                {
                    data = null,
                    message = "Success add/update Data!",
                    status = true
                };
            }
            catch (Exception ex)
            {
                return new ApiResponseObj
                {
                    data = null,
                    message = ex.Message,
                    status = false
                };
            }
        }

        [HttpPost]
        public async Task<ApiResponseObj> DeleteProducts(Guid uId)
        {
            try
            {
                var checkId = await _productRepository.GetTaskByIdAsync(uId);
                if (checkId == null)
                {
                    return new ApiResponseObj
                    {
                        data = null,
                        message = "Data tidak ditemukan!",
                        status = false
                    };
                }
                else
                {
                    await _productRepository.DeleteTaskAsync(uId);
                    return new ApiResponseObj
                    {
                        data = null,
                        message = "Sukses Menghapus Data!",
                        status = true
                    };
                }
            }
            catch(Exception ex)
            {
                return new ApiResponseObj
                {
                    data = null,
                    message = ex.Message,
                    status = false
                };
            }
        }

        [HttpGet]
        public async Task<ApiResponseObj> GetById(Guid uId)
        {
            try
            {
                var checkId = await _productRepository.GetTaskByIdAsync(uId);
                if (checkId == null)
                {
                    return new ApiResponseObj
                    {
                        data = null,
                        message = "Data tidak ditemukan!",
                        status = false
                    };
                }
                else
                {

                    return new ApiResponseObj
                    {
                        data = checkId,
                        message = "Sukses Menampilkan Data!",
                        status = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponseObj
                {
                    data = null,
                    message = ex.Message,
                    status = false
                };
            }
        }
        [HttpGet]
        public async Task<ApiResponseObj> GetAllProducts()
        {
            try
            {
                var checkId = await _productRepository.GetTasksAsync();
                if (checkId == null)
                {
                    return new ApiResponseObj
                    {
                        data = null,
                        message = "Data Kosong masukan data terlebih dahulu!",
                        status = false
                    };
                }
                else
                {

                    return new ApiResponseObj
                    {
                        data = checkId,
                        message = "Sukses Menampilkan Data!",
                        status = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponseObj
                {
                    data = null,
                    message = ex.Message,
                    status = false
                };
            }
        }
    }
}
