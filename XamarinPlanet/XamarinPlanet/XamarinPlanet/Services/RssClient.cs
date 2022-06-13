using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using XamarinPlanet.Models;
using XamarinPlanet.Services;
using static Newtonsoft.Json.Formatting;
using Formatting = System.Xml.Formatting;

namespace XamarinPlanet
{
    public class RssClient : IRssClient
    {
        private readonly ILogger _logger;

        public RssClient(ILogger logger)
        {
            _logger = logger;
        }
        
        public async Task<List<TResult>> DownloadItems<TResult>(string itemName, bool hideParseException = true)
        {
            HttpMessageHandler handler = new HttpClientHandler();
            handler = new LoggerHttpMessageHandler(handler);
            using var client = new HttpClient(handler);
            var sting = await client.GetStringAsync("https://www.planetxamarin.com/feed");
            
            var doc = new XmlDocument();
            doc.LoadXml(sting);

            var items = new List<TResult>();

            foreach (XmlElement childNode in doc["rss"]["channel"].ChildNodes)
            {
                try
                {
                    if (childNode.Name == itemName)
                    {
                        var json = JsonConvert.SerializeXmlNode(childNode, None, true);
                        _logger.LogDebugMessage(json);
                        items.Add(JsonConvert.DeserializeObject<TResult>(json));
                    }
                }
                catch (Exception ex)
                {
                    switch (hideParseException)
                    {
                        case true:
                            _logger.LogError(ex);
                            break;
                        default:
                            throw;
                    }
                }
            }

            return items;
        }
    }
}