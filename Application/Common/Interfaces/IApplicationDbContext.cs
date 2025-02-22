using System.Collections.Generic;
using System.Text.RegularExpressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<AnalysisType> AnalysisTypes { get; set; }
        DbSet<ProductAnalysisTypes> ProductAnalysisTypes { get; set; }
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}