using Application.AnalysisTypes.Queries.GetAll;
using Domain.Entities;
using FluentAssertions;

namespace Application.IntegrationTests.AnalysisTypes.Queries
{
    using static Testing;

    public class GetAllTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldReturnList()
        {
            await AddAsync(new List<AnalysisType>
            {
                new() { Name = "Microbiological"},
                new() { Name = "Nutritional"}
            });

            var query = new GetAllQuery();

            var result = await SendAsync(query);

            result.Should().HaveCount(2);
        }
    }
}