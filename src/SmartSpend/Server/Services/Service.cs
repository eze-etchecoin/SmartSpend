using SmartSpend.Domain.Core.Entities;
using SmartSpend.Domain.Core.Repository;

namespace SmartSpend.Server.Services
{
    public abstract class Service<T> : IService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
