using SmartSpend.Domain.Model;
using SmartSpend.Persistence.DynamoDb.Repositories;

namespace SmartSpend.UnitTests.DynamoDB.Repositories
{
    public class CategoryRepositoryTests
    {
        private readonly CategoryRepository _repo;

        public CategoryRepositoryTests()
        {
            _repo = new CategoryRepository(null);
        }

        [Fact]
        public async Task Insert()
        {
            var category = new Category
            {
                Description = "Test"
            };

            await _repo.Insert(category);
        }
    }
}
