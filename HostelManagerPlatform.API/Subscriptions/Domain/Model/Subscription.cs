// Ruta: Subscriptions/Domain/Model/Subscription.cs
namespace HostelManagerPlatform.API.Subscriptions.Domain.Model
{
    public class Subscription
    {
        public int Id { get; set; }
        public string TypePlan { get; set; }
        public string NumberCard { get; set; }
        public string Date { get; set; }
        public string Cvv { get; set; }
    }
}