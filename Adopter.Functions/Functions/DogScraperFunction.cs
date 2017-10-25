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

namespace dogfunctions.Functions
{
    public static class DogScraperFunction
    {
        [FunctionName(nameof(DogScraperFunction))]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetDogDetails/{name}")]HttpRequestMessage req, string name, TraceWriter log)
        {
            HttpClient client = new HttpClient();

            //string name = req.GetQueryNameValuePairs()
                //.FirstOrDefault(q => string.Compare(q.Key, "breed", true) == 0)
                //.Value;

            string html = await client.GetStringAsync($"http://dogtime.com/dog-breeds/{name}");

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var dogName = doc.DocumentNode
                             .Descendants("h1")
                             .Select(x => x.InnerText)
                             .FirstOrDefault();

            var dogDesc = doc.DocumentNode
                         .Descendants("h2")
                         .Select(x => x.Descendants("p"))
                         .FirstOrDefault()
                         .Select(x => x.InnerText)
                         .FirstOrDefault();

            var parameters = doc.DocumentNode
                                         .Descendants("span")
                                         .Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Contains("item-trigger-title"))
                                         .Select(x => x.InnerText.Replace(" ", string.Empty));

            var scores = doc.DocumentNode
                                     .Descendants("span")
                                     .Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Contains("item-trigger-title"))
                                     .Select(x => x.NextSibling)
                                     //.Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Contains("star-block stars-column"))
                                     .SelectMany(x => x.Descendants("span"))
                                     //.Where(x=>x.Attributes["class"].Value.Contains("star"))
                                     .Select(x => x.Attributes["class"].Value.Last().ToString());

            Dictionary<string, string> result = new Dictionary<string, string>();
            var finalResult = new Dictionary<string, object>();

            finalResult.Add("dogName", dogName);
            finalResult.Add("dogDescription", dogDesc);

            for (int i = 0; i < parameters.Count(); i++)
            {
                if (!result.ContainsKey(parameters.ElementAt(i)))
                    //  result.Add(parameters.ElementAt(i)+"1", scores.ElementAt(i));
                    result.Add(parameters.ElementAt(i), scores.ElementAt(i));
            }

            finalResult.Add("parameters", result);

            return req.CreateResponse(HttpStatusCode.OK, finalResult);

        }
        
    }
}
