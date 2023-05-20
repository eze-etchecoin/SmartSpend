using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace SmartSpend.UnitTests.DynamoDB.Repositories
{
    public class BaseDynamoDbRepositoryTest
    {
        protected readonly DynamoDBContext DynamoDBContext;

        public BaseDynamoDbRepositoryTest()
        {
            DynamoDBContext = new DynamoDBContext(
                new AmazonDynamoDBClient(
                    Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PUBLICKEY"),
                    Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PRIVATEKEY"),
                    Amazon.RegionEndpoint.USEast1));
        }
    }
}
