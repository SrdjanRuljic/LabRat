using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.AnalysisTypes.Queries.GetAll
{
    public class GetAllQueryViewModel : IMapFrom<AnalysisType>
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnalysisType, GetAllQueryViewModel>();
        }
    }
}