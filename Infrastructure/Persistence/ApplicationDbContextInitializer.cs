using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitializer(
    ApplicationDbContext context,
    ILogger<ApplicationDbContextInitializer> logger)
{
    public async Task InitialiseAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (context.Database.IsSqlServer())
            {
                await context.Database.MigrateAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAnalysisTypesAsync(CancellationToken cancellationToken)
    {
        var types = new List<AnalysisType>()
        {
            new() { Name = AnalysisTypes.Microbiological.ToString() },
            new() { Name = AnalysisTypes.Nutritional.ToString() },
        };

        await context.AnalysisTypes.AddRangeAsync(types, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await TrySeedAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }

    public async Task TrySeedAsync(CancellationToken cancellationToken)
    {
        if (!await context.AnalysisTypes.AnyAsync(cancellationToken))
            await SeedAnalysisTypesAsync(cancellationToken);
        else
            return;
    }
}