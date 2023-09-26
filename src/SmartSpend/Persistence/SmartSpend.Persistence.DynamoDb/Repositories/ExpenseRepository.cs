using AutoMapper;
using SmartSpend.Domain.Services.EntitiesRepositories;
using SmartSpend.Persistence.DynamoDb.Entities;

namespace SmartSpend.Persistence.DynamoDb.Repositories
{
    public class ExpenseRepository : DynamoBaseRepository<Expense, Domain.Model.Expense>, IExpenseRepository
    {
        public ExpenseRepository(SmartSpendDbContext context) : base(context)
        {
            
        }

        protected override void ConfigRepositoryMapper(MapperConfigurationExpression mapperConfig)
        {
            mapperConfig.CreateMap<Expense, Domain.Model.Expense>()
                .ReverseMap()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id.ToString()));
        }
    }
}
