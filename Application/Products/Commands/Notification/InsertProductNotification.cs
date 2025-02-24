using MediatR;

namespace Application.Products.Commands.Notification
{
    public class InsertProductNotification : INotification
    {
        public string AnalysisType { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
    }
}