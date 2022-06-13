using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using XamarinPlanet.Models;
using Formatting = Newtonsoft.Json.Formatting;

namespace XamarinPlanet
{
    public class MainPageModel : BasePageModel
    {
        private string _text;

        public MainPageModel(ILogger logger) : base(logger)
        {
        }

        public override async void ViewAppeared()
        {
           
                var client = new HttpClient();
                var sting = await client.GetStringAsync("https://www.planetxamarin.com/feed");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sting);

                var items = new List<Item>();
                var contributors = new List<Contributor>();

                foreach (XmlElement childNode in doc["rss"]["channel"].ChildNodes)
                {
                    try
                    {
                        if (childNode.Name == "item")
                        {
                            var json = JsonConvert.SerializeXmlNode(childNode, Formatting.None, true);
                            Logger.LogDebugMessage(json);
                            items.Add(JsonConvert.DeserializeObject<Item>(json));
                        }
                        else if (childNode.Name == "a10:contributor")
                        {
                            var json = JsonConvert.SerializeXmlNode(childNode, Formatting.None, true);
                            Logger.LogDebugMessage(json);
                            contributors.Add(JsonConvert.DeserializeObject<Contributor>(json));
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                    }
                }
                
                // var json = JsonConvert.SerializeXmlNode(doc.LastChild, Formatting.None, true);
                // var myDeserializedClass = JsonConvert.DeserializeObject<Rss>(json);
        
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}