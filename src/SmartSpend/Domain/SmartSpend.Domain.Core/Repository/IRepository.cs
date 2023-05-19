using SmartSpend.Domain.Core.Entities;

namespace SmartSpend.Domain.Core.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void GetAll();
    }
}
