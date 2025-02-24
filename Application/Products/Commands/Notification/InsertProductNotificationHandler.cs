using Application.Common.Interfaces;
using MassTransit;
using MediatR;

namespace Application.Products.Commands.Notification
{
    public class InsertProductNotificationHandler(IPublishEndpoint publishEndpoint,
        IDateTimeService dateTimeService) :
        INotificationHandler<InsertProductNotification>
    {
        public async Task Handle(InsertProductNotification notification, CancellationToken cancellationToken)
        {
            await publishEndpoint.Publish<IAnalysisMessage>(new
            {
                notification.SerialNumber,
                DateTime = dateTimeService.Now,
                notification.AnalysisType
            }, cancellationToken);
        }
    }
}