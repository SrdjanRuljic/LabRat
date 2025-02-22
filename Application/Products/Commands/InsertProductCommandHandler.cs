using Application.Common.Interfaces;
using Application.Exceptions;
using Application.Products.Commands.Notification;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands
{
    public class InsertProductCommandHandler(IApplicationDbContext context,
        IMediator mediator)
        : IRequestHandler<InsertProductCommand, Guid>
    {
        public async Task<Guid> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid(out var errorMessage))
                throw new BadRequestException(errorMessage);

            var entity = new Product
            {
                Name = request.Name,
                SerialNumber = request.SerialNumber
            };

            if (request.AnalysisTypeIds != null && request.AnalysisTypeIds.Any())
            {
                entity.ProductAnalysisTypes = new List<ProductAnalysisTypes>();

                foreach (long id in request.AnalysisTypeIds)
                {
                    entity.ProductAnalysisTypes.Add(new ProductAnalysisTypes()
                    {
                        ProductId = entity.Id,
                        AnalysisTypeId = id
                    });
                }
            }

            context.Products.Add(entity);

            //await context.SaveChangesAsync(cancellationToken);

            await mediator.Publish(new InsertProductNotification()
            {
                Id = entity.Id
            }, cancellationToken);

            return entity.Id;
        }
    }
}