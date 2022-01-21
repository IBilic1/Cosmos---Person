using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace MyCosmos.DAO
{
    public static class CosmosDbServiceProvider
    {
        private const string Account = "...";
        private const string Key = "...";
        private const string ContainerName = "x";
        private const string DatabaseName = "x";

        private static ICosmosDBService cosmosDBService;
        public static ICosmosDBService CosmosDBService { get => cosmosDBService; }

        public async static Task Init()
        {
            CosmosClient cosmosClient = new CosmosClient(Account,Key);
            cosmosDBService = new CosmosDBService(cosmosClient, DatabaseName, ContainerName);
            DatabaseResponse database = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await database.Database.CreateContainerIfNotExistsAsync(ContainerName,"/id");
        }




    }
}