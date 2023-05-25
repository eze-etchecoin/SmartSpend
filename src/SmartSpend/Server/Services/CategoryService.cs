using AutoMapper;
using SmartSpend.Domain.Model;
using SmartSpend.Domain.Services.EntitiesRepositories;
using SmartSpend.Shared;

namespace SmartSpend.Server.Services
{
    public class CategoryService : Service<Category>
    {
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository) : base(repository)
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>()
                    .ReverseMap();

            }).CreateMapper();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllDTO()
        {
            var entities = await GetAll();

            return _mapper.Map<IEnumerable<CategoryDTO>>(entities);
        }
    }
}
