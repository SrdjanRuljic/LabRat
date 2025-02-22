using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductAnalysisTypesConfiguration : IEntityTypeConfiguration<ProductAnalysisTypes>
    {
        public void Configure(EntityTypeBuilder<ProductAnalysisTypes> builder)
        {
            builder.HasKey(x => new { x.AnalysisTypeId, x.ProductId });

            builder.HasOne(x => x.AnalysisType)
                   .WithMany(x => x.ProductAnalysisTypes)
                   .HasForeignKey(x => x.AnalysisTypeId);

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.ProductAnalysisTypes)
                   .HasForeignKey(x => x.ProductId);
        }
    }
}