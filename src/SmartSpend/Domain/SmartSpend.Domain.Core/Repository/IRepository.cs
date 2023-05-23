using SmartSpend.Domain.Core.Entities;

namespace SmartSpend.Domain.Core.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Insert(T entity);
        Task Insert(IEnumerable<T> entities);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}
