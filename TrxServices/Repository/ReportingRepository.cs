using Microsoft.EntityFrameworkCore;
using TrxServices.Interfaces;
using TrxServices.Models;

namespace TrxServices.Repository
{
    public class ReportingRepository : IReportingRepository
    {
        private readonly TrxServicesContext _dbContext;
        public ReportingRepository(TrxServicesContext context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<DailyReport>> GetDailyReport()
        {
            var trx = await _dbContext.DailyReports.ToListAsync();
            return trx.Select(dr => new DailyReport
            {
                ProductsName = dr.ProductsName,
                TotalDaily = dr.TotalDaily
            });
        }

        public async Task<IEnumerable<MonthlyReport>> GetMontlyReport()
        {
            var trx = await _dbContext.MonthlyReports.ToListAsync();
            return trx.Select(dr => new MonthlyReport
            {
                ProductsName = dr.ProductsName,
                TotalMonthly= dr.TotalMonthly
            });

        }

        public async Task<Reporting> GetReportingById(Guid uId)
        {
            var trx = await _dbContext.Reportings.FirstOrDefaultAsync(u => u.Id == uId);

            if (trx == null)
            {
                return null;
            }

            return new Reporting
            {
                Id = trx.Id,
                TransactionId = trx.TransactionId,
                CreatedDate = trx.CreatedDate,
                TotalPayment = trx.TotalPayment 
            };
        }

        public async Task<IEnumerable<WeeklyReport>> GetWeeklyReport()
        {
            var trx = await _dbContext.WeeklyReports.ToListAsync();
            return trx.Select(dr => new WeeklyReport
            {
                ProductsName = dr.ProductsName,
                TotalWeekly = dr.TotalWeekly
            });
        }

        public async Task<IEnumerable<YearlyReport>> GetYearlyReport()
        {
            var trx = await _dbContext.YearlyReports.ToListAsync();
            return trx.Select(dr => new YearlyReport
            {
                ProductsName = dr.ProductsName,
                TotalYearly = dr.TotalYearly
            });
        }
    }
}
