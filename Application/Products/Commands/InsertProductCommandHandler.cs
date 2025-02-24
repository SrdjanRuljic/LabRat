using Application.Common.Interfaces;
using Application.Products.Commands.Notification;
using Domain.Entities;
using MassTransit.Initializers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Commands
{
    public class InsertProductCommandHandler(IApplicationDbContext context,
        IMediator mediator)
        : IRequestHandler<InsertProductCommand, Guid>
    {
        public async Task<Guid> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Name = request.Name,
                SerialNumber = request.SerialNumber,
                ProductAnalysisTypes = request.AnalysisTypeIds?
                    .Select(id => new ProductAnalysisTypes { AnalysisTypeId = id })
                    .ToList() ?? []
            };

            context.Products.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            if (entity.ProductAnalysisTypes.Count > 0)
            {
                var analysisTypes = await context.AnalysisTypes
                .Where(at => request.AnalysisTypeIds!.Contains(at.Id))
                .ToDictionaryAsync(at => at.Id, at => at.Name, cancellationToken);

                var notifications = entity.ProductAnalysisTypes
                    .Select(item => new InsertProductNotification
                    {
                        SerialNumber = entity.SerialNumber,
                        AnalysisType = analysisTypes.GetValueOrDefault(item.AnalysisTypeId)
                    })
                    .Where(n => n.AnalysisType is not null)
                    .ToList();

                var publishTasks = notifications.Select(n => mediator.Publish(n, cancellationToken));

                await Task.WhenAll(publishTasks);
            }

            return entity.Id;
        }
    }
}