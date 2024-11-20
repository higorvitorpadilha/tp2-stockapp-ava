namespace StockApp.Application.Interfaces
{
    public interface IWebhookService
    {
        Task SendWebhookAsync(string url, object payload);
        void RegisterWebhook(string url, string eventType);
    }
}