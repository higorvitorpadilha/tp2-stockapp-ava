﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StockApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("stock")]
        public ActionResult<IEnumerable<StockReportItem>> GetStockReport()
        {
            var stockData = new List<StockReportItem>
            {
                new StockReportItem { Name = "Product A", Stock = 100 },
                new StockReportItem { Name = "Product B", Stock = 150 },
                new StockReportItem { Name = "Product C", Stock = 75 }
            };

            return Ok(stockData);
        }

        [HttpGet("sales")]
        public ActionResult<IEnumerable<SalesReportItem>> GetSalesReport()
        {
            var salesData = new List<SalesReportItem>
            {
                new SalesReportItem { Date = "2023-01", Sales = 1000 },
                new SalesReportItem { Date = "2023-02", Sales = 1200 },
                new SalesReportItem { Date = "2023-03", Sales = 1100 }
            };

            return Ok(salesData);
        }
    }

    public class StockReportItem
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }

    public class SalesReportItem
    {
        public string Date { get; set; }
        public int Sales { get; set; }
    }
}