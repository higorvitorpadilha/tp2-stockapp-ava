using System;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
    public interface IReportService
    {
        Task<byte[]> GenerateStockReportAsync();
        Task<byte[]> GenerateSalesReportAsync();
        Task<byte[]> GenerateProductPerformanceReportAsync(DateTime startDate, DateTime endDate);
        Task<byte[]> GenerateCategoryDistributionReportAsync();
        Task<byte[]> GenerateMonthlyRevenueReportAsync(int year);
        Task<byte[]> GenerateTopSellingProductsReportAsync(int top = 10);
        Task<byte[]> GenerateLowStockAlertReportAsync(int threshold = 10);
        Task<byte[]> GenerateProfitMarginReportAsync();
        Task<string> GenerateCSVReportAsync(string reportType);
        Task<byte[]> GenerateCustomReportAsync(ReportParameters parameters);
    }

    public class ReportParameters
    {
        public string ReportType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Limit { get; set; }
        public string[] Categories { get; set; }
        public string Format { get; set; }
    }
}