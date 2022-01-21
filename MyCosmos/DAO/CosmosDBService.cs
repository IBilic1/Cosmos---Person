using Microsoft.Azure.Cosmos;
using MyCosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCosmos.DAO
{
    public class CosmosDBService : ICosmosDBService
    {
        private readonly Container container;

        public CosmosDBService(CosmosClient cosmosClient,string databaseName,string containerName)
        {
            container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task DeletePersonAsync(Person person)
        =>await container.DeleteItemAsync<Person>(person.Id, new PartitionKey(person.Id));

        public async Task<IEnumerable<Person>> GetPeopleAsync(string queryString)
        {
            List<Person> people = new List<Person>();
            var query = container.GetItemQueryIterator<Person>(new QueryDefinition(queryString));

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                people.AddRange(response.ToList());
            }
            return people;
        }

        public async Task<Person> GetPersonAsync(string id)
        {
            try
            {
                return await container.ReadItemAsync<Person>(id, new PartitionKey(id));
            }
            catch (CosmosException e) when (e.StatusCode==System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task InsertPersonAsync(Person person)
        => await container.CreateItemAsync(person,new PartitionKey( person.Id));

        public async Task UpdatePersonAsync(Person person)
        => await container.UpsertItemAsync<Person>(person, new PartitionKey(person.Id));
    }
}