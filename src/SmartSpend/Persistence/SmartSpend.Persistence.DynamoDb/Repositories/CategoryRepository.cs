using AutoMapper;
using SmartSpend.Domain.Services.EntitiesRepositories;
using SmartSpend.Persistence.DynamoDb.Entities;

namespace SmartSpend.Persistence.DynamoDb.Repositories
{
    public class CategoryRepository : DynamoBaseRepository<Category, Domain.Model.Category>, ICategoryRepository
    {
        public CategoryRepository(SmartSpendDbContext context) : base(context)
        {
            
        }

        protected override void ConfigRepositoryMapper(MapperConfigurationExpression mapperConfig)
        {
            mapperConfig.CreateMap<Category, Domain.Model.Category>()
                .ReverseMap();
        }
    }
}
