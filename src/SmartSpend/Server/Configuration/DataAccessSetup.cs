using Amazon.DynamoDBv2;
using SmartSpend.Domain.Services.EntitiesRepositories;
using SmartSpend.Persistence.DynamoDb;
using SmartSpend.Persistence.DynamoDb.Repositories;

namespace SmartSpend.Server.Configuration
{
    public static class DataAccessSetup
    {
        public static void ConfigureDataAccess(this IServiceCollection services)
        {
            var publicKey = Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PUBLICKEY");
            var privateKey = Environment.GetEnvironmentVariable("SMARTSPEND_DATAACCESS_PRIVATEKEY");

            services.AddSingleton(sp =>
                new AmazonDynamoDBClient(publicKey, privateKey, Amazon.RegionEndpoint.USEast1));

            services.AddSingleton<SmartSpendDbContext>();

            #region Repositories

            services.AddSingleton<ICategoryRepository, CategoryRepository>();

            #endregion
        }
    }
}
