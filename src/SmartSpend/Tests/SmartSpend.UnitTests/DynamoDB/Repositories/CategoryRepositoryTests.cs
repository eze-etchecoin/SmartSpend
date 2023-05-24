using SmartSpend.Domain.Model;
using SmartSpend.Persistence.DynamoDb.Repositories;
using Xunit.Abstractions;

namespace SmartSpend.UnitTests.DynamoDB.Repositories
{
    public class CategoryRepositoryTests : BaseDynamoDbRepositoryTest
    {
        private readonly CategoryRepository _repo;
        private readonly ITestOutputHelper _outputHelper;

        public CategoryRepositoryTests(ITestOutputHelper outputHelper)
        {
            _repo = new CategoryRepository(DbContext);
            _outputHelper = outputHelper;
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
        public async Task Insert100()
        {
            var rnd = new Random();
            var categories = new List<Category>();

            for (int i = 0; i < 100; i++)
            {
                categories.Add(GetCategory(rnd));
                Thread.Sleep(2);
            }

            await _repo.Insert(categories);
        }

        [Fact]
        public async Task GetById()
        {
            var guid = Guid.Parse("d338daab-e343-4ecf-985e-f4477cbd9697");
            var result = await _repo.GetById(guid);

            Assert.NotNull(result);
            Assert.Equal("Test218452", result.Description);
        }

        [Fact]
        public async Task GetAll()
        {
            var results = await _repo.GetAll();

            Assert.NotNull(results);
            Assert.NotEmpty(results);

            _outputHelper.WriteLine($"Results count: {results.Count()}");
        }

        private static Category GetCategory(Random rnd) => new Category
        {
            Description = "Test" + rnd.Next(1000000)
        };
    }
}
