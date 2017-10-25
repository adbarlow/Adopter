using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using dogfunctions.Helpers;
using dogfunctions.Model;
using Newtonsoft.Json;

namespace dogfunctions.Functions
{
    public class DogDbFunction
    {
        [FunctionName(nameof(DogDbFunction))]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "InsertDogIntoDB/{name}")]HttpRequestMessage req, string name, TraceWriter log)
        {
            CosmosDBRepository.Initialize();

            HttpClient _client = new HttpClient();
            var dogres = await _client.GetStringAsync($"https://dogfunction.azurewebsites.net/api/GetDogDetails/{name}");

            Dog dog = JsonConvert.DeserializeObject<Dog>(dogres);

            AddDogToDB(dog);

            return req.CreateResponse(HttpStatusCode.OK, dogres);
        }


        public static void AddDogToDB(Dog dog)
        {
            var existingDogs = CosmosDBRepository.GetItemsFilteredAsync<Dog>(Keys.CosmosDB.CollectionId, x => x.dogName == dog.dogName).Result;

            var existingDog = existingDogs.FirstOrDefault();

            if (existingDog == default(Dog))
            {
                dog.id = Guid.NewGuid().ToString();
               
                var res = CosmosDBRepository.CreateItemAsync(Keys.CosmosDB.CollectionId, dog);
            }
        }
    }
}
