using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrxServices.Interfaces;
using static MiniProjects.Repository.WebApiHelper;
namespace TrxServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IReportingRepository _reportRepository;
        public ReportingController(IReportingRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        [HttpGet]
        public async Task<ApiResponseObj> GetDailyReport()
        {
            try
            {
                var checkId = await _reportRepository.GetDailyReport();
                if (checkId == null)
                {
                    return new ApiResponseObj
                    {
                        data = null,
                        message = "Data Kosong !",
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
        public async Task<ApiResponseObj> GetYearlyReport()
        {
            try
            {
                var checkId = await _reportRepository.GetYearlyReport();
                if (checkId == null)
                {
                    return new ApiResponseObj
                    {
                        data = null,
                        message = "Data Kosong !",
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
        public async Task<ApiResponseObj> GetMonthlyReport()
        {
            try
            {
                var checkId = await _reportRepository.GetMontlyReport();
                if (checkId == null)
                {
                    return new ApiResponseObj
                    {
                        data = null,
                        message = "Data Kosong !",
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
