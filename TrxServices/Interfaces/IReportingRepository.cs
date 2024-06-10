using System.Threading.Tasks;
using TrxServices.Models;
namespace TrxServices.Interfaces
{
    public interface IReportingRepository
    {
        Task<Reporting> GetReportingById(Guid uId);
        Task<IEnumerable<DailyReport>> GetDailyReport();
        Task<IEnumerable<MonthlyReport>> GetMontlyReport();
        Task<IEnumerable<WeeklyReport>> GetWeeklyReport();
        Task<IEnumerable<YearlyReport>> GetYearlyReport();


    }
}
