using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using SmartSpend.Domain.Core.Entities;
using SmartSpend.Domain.Core.Repository;
using SmartSpend.Persistence.DynamoDb.Entities;

namespace SmartSpend.Persistence.DynamoDb.Repositories
{
    public abstract class DynamoBaseRepository<TDynamoEntity, TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TDynamoEntity : DynamoBaseEntity
    {
        protected readonly IMapper Mapper;
        private readonly DynamoDBContext _context;

        public DynamoBaseRepository(DynamoDBContext context)
        {
            _context = context;

            ConfigAutoMapper(out Mapper);
        }

        protected abstract void ConfigAutoMapper(out IMapper mapper);

        public async Task Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
