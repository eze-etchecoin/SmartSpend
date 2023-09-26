using Amazon.DynamoDBv2;
using SmartSpend.Domain.Services.EntitiesRepositories;
using SmartSpend.Persistence.DynamoDb;
using SmartSpend.Persistence.DynamoDb.Repositories;

namespace SmartSpend.Server.Configuration
{
    public static class DataAccessSetup
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var publicKey = Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PUBLICKEY");
            var privateKey = Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PRIVATEKEY");

            var region = Amazon.RegionEndpoint.GetBySystemName(configuration["AWSRegion"]);

            services.AddSingleton(sp =>
                new AmazonDynamoDBClient(publicKey, privateKey, region));

            services.AddSingleton<SmartSpendDbContext>();

            #region Repositories

            services.AddSingleton<ICategoryRepository, CategoryRepository>();

            #endregion
        }
    }
}
