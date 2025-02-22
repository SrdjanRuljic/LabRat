using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.AnalysisTypes.Queries.GetAll
{
    public class GetAllQueryHandler(IApplicationDbContext context, IMapper mapper)
        : IRequestHandler<GetAllQuery, IList<GetAllQueryViewModel>>
    {
        public async Task<IList<GetAllQueryViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken) =>
            await context.AnalysisTypes.ProjectTo<GetAllQueryViewModel>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}