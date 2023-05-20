using Amazon.DynamoDBv2;
using SmartSpend.Persistence.DynamoDb;

namespace SmartSpend.UnitTests.DynamoDB.Repositories
{
    public class BaseDynamoDbRepositoryTest
    {
        protected readonly SmartSpendDbContext DbContext;

        public BaseDynamoDbRepositoryTest()
        {
            DbContext = new SmartSpendDbContext(
                new AmazonDynamoDBClient(
                    Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PUBLICKEY"),
                    Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PRIVATEKEY"),
                    Amazon.RegionEndpoint.USEast1));
        }
    }
}
