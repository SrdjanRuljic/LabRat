using Application.Common.Exceptions;
using Application.Products.Commands;
using Domain.Entities;
using FluentAssertions;

namespace Application.IntegrationTests.Products.Commands
{
    using static Testing;

    public class InsertProductTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldCreateTodoList()
        {
            var command = new InsertProductCommand()
            {
                Name = "Meet",
                SerialNumber = "123"
            };

            var id = await SendAsync(command);

            var list = await FindAsync<Product>(id);

            list.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new InsertProductCommand();

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }
    }
}