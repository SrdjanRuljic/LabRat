using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AnalysisTypeConfiguration : IEntityTypeConfiguration<AnalysisType>
    {
        public void Configure(EntityTypeBuilder<AnalysisType> builder)
        {
        }
    }
}