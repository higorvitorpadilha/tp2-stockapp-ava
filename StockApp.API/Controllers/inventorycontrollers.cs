using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StockApp.API.Services;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost("replenish")]
        public async Task<IActionResult> ReplenishStock()
        {
            await _inventoryService.ReplenishStockAsync();
            return Ok("Stock replenished successfully");
        }

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStockProducts([FromQuery] int threshold = 10)
        {
            var products = await _inventoryService.GetLowStockProductsAsync(threshold);
            return Ok(products);
        }

        [HttpGet("total-value")]
        public async Task<IActionResult> GetTotalStockValue()
        {
            var totalValue = await _inventoryService.GetTotalStockValueAsync();
            return Ok(new { TotalValue = totalValue });
        }
    }
}