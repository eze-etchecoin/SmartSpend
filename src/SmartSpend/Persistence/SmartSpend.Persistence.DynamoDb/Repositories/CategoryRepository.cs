using AutoMapper;
using SmartSpend.Domain.Services.EntitiesRepositories;
using SmartSpend.Persistence.DynamoDb.Entities;

namespace SmartSpend.Persistence.DynamoDb.Repositories
{
    internal class CategoryRepository : DynamoBaseRepository<Category, Domain.Model.Category>, ICategoryRepository
    {
        
        
        protected override void ConfigAutoMapper(out IMapper mapper)
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, Domain.Model.Category>()
                    .ReverseMap();

            }).CreateMapper();
        }
    }
}
