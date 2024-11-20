using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;

namespace StockApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly IWebhookService _webhookService;

        public WebhookController(IWebhookService webhookService)
        {
            _webhookService = webhookService;
        }

        [HttpPost("register")]
        public IActionResult RegisterWebhook([FromBody] WebhookRegistration registration)
        {
            _webhookService.RegisterWebhook(registration.Url, registration.EventType);
            return Ok();
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook([FromBody] WebhookDto webhookDto)
        {
            // Implementação da lógica de webhook
            if (webhookDto == null)
            {
                return BadRequest("Invalid webhook data");
            }

            // Aqui você pode adicionar lógica para processar o webhook recebido
            // Por exemplo, você pode querer verificar o tipo de evento e agir de acordo

            switch (webhookDto.EventType)
            {
                case "product.created":
                    // Lógica para lidar com a criação de produto
                    break;
                case "product.updated":
                    // Lógica para lidar com a atualização de produto
                    break;
                case "product.deleted":
                    // Lógica para lidar com a exclusão de produto
                    break;
                default:
                    return BadRequest("Unknown event type");
            }

            // Se tudo estiver ok, retorne um 200 OK
            return Ok();
        }
    }

    public class WebhookRegistration
    {
        public string Url { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
    }

    public class WebhookDto
    {
        public string EventType { get; set; } = string.Empty;
        public object Payload { get; set; } = new();
    }
}