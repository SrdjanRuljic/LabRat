using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.AnalysisTypes.Queries.GetAll
{
    public class GetAllQuery : IRequest<IList<GetAllQueryViewModel>>
    {
    }
}