using Amazon.DynamoDBv2;
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
        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _context;

        public DynamoBaseRepository()
        {
            _client = new AmazonDynamoDBClient();
            _context = new DynamoDBContext(_client);
            ConfigAutoMapper(out Mapper);
        }

        protected abstract void ConfigAutoMapper(out IMapper mapper);

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
