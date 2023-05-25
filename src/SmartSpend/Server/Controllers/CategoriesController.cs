using Microsoft.AspNetCore.Mvc;
using SmartSpend.Domain.Services.EntitiesRepositories;
using SmartSpend.Server.Services;
using SmartSpend.Shared;

namespace SmartSpend.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly CategoryService _service;

        public CategoriesController(
            ILogger<CategoriesController> logger,
            ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _service = new CategoryService(categoryRepository);
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            try
            {
                return await _service.GetAllDTO();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Categories GetAll Error");
                throw;
            }
        }

        [HttpGet("GetPage/{pageSize}/{pageNumber}")]
        public IEnumerable<WeatherForecast> GetPage(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}