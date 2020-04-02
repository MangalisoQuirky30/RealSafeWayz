using realSafewayz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace realSafewayz.Services
{
    public class CosmosDbConnection
    {
        //ALL THE METHODS RELATRED TO THE  DATABASE COME HERE
        // The Azure Cosmos DB endpoint for running this sample.
        private static readonly string EndpointUri = "https://another-test.documents.azure.com:443/";

        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "deWL83xCM7AlRTv5XnMN1td1OnOIJotNlCZxzZlVSLfTWNoiqhuofikRjK0GKX7nBQtGhAsSMkq1lUJml116Fw==";

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        // The name of the database and container we will create
        private string databaseId = "SafeWaysIncidents";
        private string containerId = "SafeWaysIncidentsContainer";

        // <Main>
        public static async Task TestStuff()
        {
            try
            {
                var dbConnection = new CosmosDbConnection();
                await dbConnection.GetStartedAsync();

            }
            catch (CosmosException de)
            {
                Exception baseException = de.GetBaseException();
            }
            catch (Exception e)
            {
                var error = e;
            }
            finally
            {

            }
        }

        public async Task GetStartedAsync()
        {
            // Create a new instance of the Cosmos Client
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
            await this.CreateDatabaseAsync();
            await this.CreateContainerAsync();
            await this.AddItemsToContainerAsync();
        }

        private async Task CreateDatabaseAsync()
        {
            // Create a new database
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
        }
        
        private async Task CreateContainerAsync()
        {
            // Create a new container
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/Incident");
        }
        
        private async Task AddItemsToContainerAsync()
        {
            // Create a family object for the Andersen family
            IncidentReport report1 = new IncidentReport
            {
                Id = 1,
                Area = "Eerste River",
                Incident = "Shooting",
                IncidentDescription = "There was a shooting at Eerste River.",
                DislikesAmount = 3,
                UpvotesAmount = 98
            };


            try
            {
                // Read the item to see if it exists.  
                ItemResponse<IncidentReport> IncidentReport1Responce = await this.container.ReadItemAsync<IncidentReport>(report1.Incident, new PartitionKey(report1.Area));
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Create an item in the container representing the Andersen family. Note we provide the value of the partition key for this item, which is "Andersen"
                ItemResponse<IncidentReport> IncidentReport1Responce = await this.container.CreateItemAsync<IncidentReport>(report1, new PartitionKey(report1.Area));

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
            }

            IncidentReport report2 = new IncidentReport
            {
                Id = 2,
                Area = "Kuils River",
                Incident = "Stabbing",
                IncidentDescription = "There was a shooting at Kuils River.",
                DislikesAmount = 3,
                UpvotesAmount = 98
            };

            try
            {
                // Read the item to see if it exists
                ItemResponse<IncidentReport> IncidentReport2Responce = await this.container.ReadItemAsync<IncidentReport>(report2.Incident, new PartitionKey(report2.Area));
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Create an item in the container representing the Wakefield family. Note we provide the value of the partition key for this item, which is "Wakefield"
                ItemResponse<IncidentReport> IncidentReport2Responce = await this.container.CreateItemAsync<IncidentReport>(report2, new PartitionKey(report2.Area));

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
            }
        }
        
        public async Task QueryItemsAsync()
        {
            var sqlQueryText = "SELECT * FROM c WHERE c.Area = 'Eerste River'";

            var queryText = sqlQueryText;

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<IncidentReport> queryResultSetIterator = this.container.GetItemQueryIterator<IncidentReport>(queryDefinition);

            List<IncidentReport> incidentReports = new List<IncidentReport>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<IncidentReport> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (IncidentReport report in currentResultSet)
                {
                    incidentReports.Add(report);
                }
            }
        }

        private async Task ReplaceIncidentItemAsync()
        {
            ItemResponse<IncidentReport> incidentReport2Response = await this.container.ReadItemAsync<IncidentReport>("IncidentReport", new PartitionKey("IncidentReports"));
            var itemBody = incidentReport2Response.Resource;

            // update registration status from false to true
            itemBody.Area = "Mitchells Plain";
            // update grade of child

            itemBody.IncidentDescription = "There was a very bad shooting at Kuils River.";

            // replace the item with the updated content
            incidentReport2Response = await this.container.ReplaceItemAsync<IncidentReport>(itemBody, itemBody.Incident, new PartitionKey(itemBody.Area));
        }
    }
}