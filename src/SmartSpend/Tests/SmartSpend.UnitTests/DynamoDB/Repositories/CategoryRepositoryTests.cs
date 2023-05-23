using SmartSpend.Domain.Model;
using SmartSpend.Persistence.DynamoDb.Repositories;

namespace SmartSpend.UnitTests.DynamoDB.Repositories
{
    public class CategoryRepositoryTests : BaseDynamoDbRepositoryTest
    {
        private readonly CategoryRepository _repo;

        public CategoryRepositoryTests()
        {
            _repo = new CategoryRepository(DbContext);
        }

        [Fact]
        public async Task Insert()
        {
            var rnd = new Random();
            var category = new Category
            {
                Description = "Test" + rnd.Next(1000000),
            };

            await _repo.Insert(category);
        }

        [Fact]
        public async Task Insert10()
        {
            var rnd = new Random();
            var categories = new List<Category>();

            for(int i = 0; i < 10; i++)
            {
                categories.Add(GetCategory(rnd));
                Thread.Sleep(5);
            }

            await _repo.Insert(categories);
        }

        [Fact]
        public async Task GetById()
        {
            var rnd = new Random();
            var category = GetCategory(rnd);

            await _repo.Insert(category);

            var inserted = await _repo.GetById(category.Id);

            Assert.NotNull(inserted);
            Assert.Equal(category.Description, inserted.Description);
        }

        private static Category GetCategory(Random rnd) => new Category
        {
            Description = "Test" + rnd.Next(1000000)
        };
    }
}
