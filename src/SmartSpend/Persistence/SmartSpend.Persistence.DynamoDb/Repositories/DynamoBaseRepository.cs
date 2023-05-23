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
        //private const string _tableName = "SmartSpend_Data";

        public DynamoBaseRepository(DynamoDBContext context)
        {
            _context = context;

            ConfigAutoMapper(out Mapper);
        }

        protected abstract void ConfigAutoMapper(out IMapper mapper);

        public async Task Insert(TEntity entity)
        {
            var dynamoEntity = Mapper.Map<TDynamoEntity>(entity);
            await _context.SaveAsync(dynamoEntity);
        }

        public async Task Insert(IEnumerable<TEntity> entities)
        {
            var dynamoEntities = Mapper.Map<IEnumerable<TDynamoEntity>>(entities);

            var batchWrite = _context.CreateBatchWrite<TDynamoEntity>();
            batchWrite.AddPutItems(dynamoEntities);

            await batchWrite.ExecuteAsync();
        }

        public async Task Delete(TEntity entity)
        {
            var dynamoEntity = Mapper.Map<TDynamoEntity>(entity);
            await _context.DeleteAsync(dynamoEntity.GlobalIdentifier);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var resultsDb = await _context
                .QueryAsync<TDynamoEntity>(typeof(TDynamoEntity).Name)
                .GetRemainingAsync();

            var results = Mapper.Map<IEnumerable<TEntity>>(resultsDb);

            return results;
        }

        public async Task Update(TEntity entity)
        {
            var dynamoEntity = Mapper.Map<TDynamoEntity>(entity);
            await _context.SaveAsync(dynamoEntity);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var hashKey = GetGlobalIdentifierFromGuidId(id);
            var result = (await _context
                .QueryAsync<TDynamoEntity>(hashKey)
                .GetRemainingAsync())
                .FirstOrDefault();

            return Mapper.Map<TEntity>(result);
        }

        private string GetGlobalIdentifierFromGuidId(Guid id) => $"{typeof(TDynamoEntity).Name}#{id}";
    }
}
