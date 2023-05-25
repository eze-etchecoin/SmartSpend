using SmartSpend.Domain.Core.Entities;

namespace SmartSpend.Server.Services
{
    public interface IService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
    }
}
