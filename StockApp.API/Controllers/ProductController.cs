using Microsoft.AspNetCore.Mvc;
using StockApp.Domain.Entities;
using StockApp.Application.Services;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>();
        private static int _productIdCounter = 1;
        private static int _reviewIdCounter = 1;
        private readonly SentimentAnalysisService _sentimentAnalysisService;

        public ProductController(SentimentAnalysisService sentimentAnalysisService)
        {
            _sentimentAnalysisService = sentimentAnalysisService;
        }

        [HttpPost("product")]
        public IActionResult AddProduct(Product product)
        {
            product.Id = _productIdCounter++;
            _products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpGet("product/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost("review")]
        public IActionResult AddReview(Review review)
        {
            var product = _products.FirstOrDefault(p => p.Id == review.ProductId);
            if (product == null)
                return NotFound("Product not found");

            review.Id = _reviewIdCounter++;
            review.Sentiment = _sentimentAnalysisService.AnalyzeSentiment(review.Text);
         
            return CreatedAtAction(nameof(GetReviewsForProduct), new { productId = review.ProductId }, review);
        }

        [HttpGet("product/{productId}/reviews")]
        public IActionResult GetReviewsForProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }
    }
}