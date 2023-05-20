using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace SmartSpend.Persistence.DynamoDb
{
    public class SmartSpendDbContext : DynamoDBContext
    {
        public SmartSpendDbContext(AmazonDynamoDBClient client) : base(client)
        {
        }
    }
}
