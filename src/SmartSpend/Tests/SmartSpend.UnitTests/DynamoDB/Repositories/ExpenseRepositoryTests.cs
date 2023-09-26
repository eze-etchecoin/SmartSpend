using SmartSpend.Domain.Model;
using SmartSpend.Persistence.DynamoDb.Repositories;
using Xunit.Abstractions;

namespace SmartSpend.UnitTests.DynamoDB.Repositories
{
    public class ExpenseRepositoryTests : BaseDynamoDbRepositoryTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private ExpenseRepository _repo;

        public ExpenseRepositoryTests(ITestOutputHelper outputHelper)
        {
            _repo = new ExpenseRepository(DbContext);
            _outputHelper = outputHelper;
        }

        [Fact]
        public async Task InsertAsync()
        {
            var rnd = new Random();
            var expense = new Expense
            {
                Description = "Test" + rnd.Next(1000000),
                Total = rnd.Next(1000),
                Category = new Category
                {
                    Description = "Test" + rnd.Next(1000000),
                }
            };

            await _repo.Insert(expense);
        }
    }
}
