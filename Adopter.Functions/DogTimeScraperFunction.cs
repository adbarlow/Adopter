using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Net;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Collections.Generic;
using Adopter.Common.Models;

namespace Adopter.Functions
{
    public static class DogTimeScraperFunction
    {
        [FunctionName("DogTimeScraperFunction")]
        public static async Task Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            await GetBreed("http://dogtime.com/dog-breeds/english-springer-spaniel");
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        }

        static async Task<BreedModel> GetBreed(string dogBreedUrl)
        {
            HttpClient client = new HttpClient();

            

            string html = await client.GetStringAsync(dogBreedUrl);

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

            result.Add("dogName", dogName);
            result.Add("dogDescription", dogDesc);

            //result.Add("temp",scores);

            for (int i = 0; i < parameters.Count(); i++)
                if (result.ContainsKey(parameters.ElementAt(i)))
                    result.Add(parameters.ElementAt(i) + "1", scores.ElementAt(i));
                else
                    result.Add(parameters.ElementAt(i), scores.ElementAt(i));

            return new BreedModel();
        }
    }
}

