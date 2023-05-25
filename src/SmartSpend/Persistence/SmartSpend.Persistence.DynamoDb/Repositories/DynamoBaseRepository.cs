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

        public DynamoBaseRepository(SmartSpendDbContext context)
        {
            _context = context;

            var mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression
                .CreateMap<DateTimeOffset, string>()
                .ConvertUsing(dto => dto.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz"));

            mapperConfigurationExpression
                .CreateMap<string, DateTimeOffset>()
                .ConvertUsing(str => DateTimeOffset.Parse(str));

            ConfigRepositoryMapper(mapperConfigurationExpression);

            Mapper = new MapperConfiguration(mapperConfigurationExpression).CreateMapper();
        }

        protected abstract void ConfigRepositoryMapper(MapperConfigurationExpression mapperConfig);

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
            await _context.DeleteAsync(dynamoEntity.Id, new DynamoDBOperationConfig
            {
                IndexName = "Id-index"
            });
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
            var hashKey = id.ToString();

            var result = (await _context
                .QueryAsync<TDynamoEntity>(hashKey, new DynamoDBOperationConfig
                {
                    IndexName = "Id-index"
                })
                .GetRemainingAsync())
                .FirstOrDefault();

            return Mapper.Map<TEntity>(result);
        }
    }
}
