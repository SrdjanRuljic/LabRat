using MediatR;

namespace Application.Products.Commands.Notification
{
    public class InsertProductNotification : INotification
    {
        public Guid Id { get; set; }
    }
}