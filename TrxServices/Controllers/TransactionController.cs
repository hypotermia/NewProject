using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrxServices.Interfaces;
using static MiniProjects.Repository.WebApiHelper;
using TrxServices.Models;
namespace TrxServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        [HttpPost]
        public async Task<ApiResponseObj> InsertUpdateTransaction([FromBody] Transaction transaction)
        {
            try
            {
                var checkId = await _transactionRepository.GetTransactionByIdAsync(transaction.Id);
                if (checkId == null)
                {
                    await _transactionRepository.AddTransactionAsync(transaction);
                }
                else
                {
                    await _transactionRepository.UpdateTransactionAsync(transaction.Id, transaction);
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
        public async Task<ApiResponseObj> DeleteTransaction(Guid uId)
        {
            try
            {
                var checkId = await _transactionRepository.GetTransactionByIdAsync(uId);
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
                    await _transactionRepository.DeleteTransactionAsync(uId);
                    return new ApiResponseObj
                    {
                        data = null,
                        message = "Sukses Menghapus Data!",
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
        public async Task<ApiResponseObj> GetById(Guid uId)
        {
            try
            {
                var checkId = await _transactionRepository.GetTransactionByIdAsync(uId);
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
        public async Task<ApiResponseObj> GetAllTransaction()
        {
            try
            {
                var checkId = await _transactionRepository.GetTransactionAsync();
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
