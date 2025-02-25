using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Respawn;

namespace Application.IntegrationTests
{
    [SetUpFixture]
    public partial class Testing
    {
        private static Respawner _checkpoint;
        private static IConfiguration _configuration;
        private static string _currentUserId = string.Empty;
        private static WebApplicationFactory<Program> _factory;
        private static IServiceScopeFactory _scopeFactory;

        public static async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            using IServiceScope scope = _scopeFactory.CreateScope();

            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public static async Task<int> CountAsync<TEntity>() where TEntity : class
        {
            using IServiceScope scope = _scopeFactory.CreateScope();

            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            return await context.Set<TEntity>().CountAsync();
        }

        public static async Task<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class
        {
            using IServiceScope scope = _scopeFactory.CreateScope();

            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public static string GetCurrentUserId() => _currentUserId;

        public static async Task ResetState()
        {
            try
            {
                await _checkpoint.ResetAsync(_configuration.GetConnectionString("StartupDb")!);
            }
            catch (Exception)
            {
            }

            _currentUserId = string.Empty;
        }

        public static async Task SendAsync(IBaseRequest request)
        {
            using IServiceScope scope = _scopeFactory.CreateScope();

            ISender sender = scope.ServiceProvider.GetRequiredService<ISender>();

            await sender.Send(request);
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using IServiceScope scope = _scopeFactory.CreateScope();

            ISender sender = scope.ServiceProvider.GetRequiredService<ISender>();

            return await sender.Send(request);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _factory?.Dispose();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
            _configuration = _factory.Services.GetRequiredService<IConfiguration>();

            _checkpoint = Respawner.CreateAsync(_configuration.GetConnectionString("LabRatDb")!, new RespawnerOptions
            {
                TablesToIgnore = ["__EFMigrationsHistory"]
            }).GetAwaiter().GetResult();
        }
    }
}