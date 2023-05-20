using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using SmartSpend.Domain.Services.EntitiesRepositories;
using SmartSpend.Persistence.DynamoDb.Entities;

namespace SmartSpend.Persistence.DynamoDb.Repositories
{
    public class CategoryRepository : DynamoBaseRepository<Category, Domain.Model.Category>, ICategoryRepository
    {
        public CategoryRepository(DynamoDBContext context) : base(context)
        {
            
        }

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
