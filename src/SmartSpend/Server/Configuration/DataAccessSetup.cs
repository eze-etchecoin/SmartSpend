using Amazon.DynamoDBv2;
using SmartSpend.Persistence.DynamoDb;

namespace SmartSpend.Server.Configuration
{
    public static class DataAccessSetup
    {
        public static void ConfigureDataAccess(this IServiceCollection services)
        {
            var publicKey = Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PUBLICKEY");
            var privateKey = Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PRIVATEEY");

            services.AddSingleton(sp =>
                new AmazonDynamoDBClient(publicKey, privateKey, Amazon.RegionEndpoint.USEast1));

            services.AddSingleton<SmartSpendDbContext>();
        }
    }
}
