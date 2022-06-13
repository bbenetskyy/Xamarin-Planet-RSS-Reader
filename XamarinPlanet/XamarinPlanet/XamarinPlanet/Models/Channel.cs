using System;
using System.Collections.Generic;

namespace XamarinPlanet.Models
{
    public class Channel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Copyright { get; set; }
        public string LastBuildDate { get; set; }
        public List<Contributor> Contributor { get; set; }
        public Image Image { get; set; }
        public List<Item> Item { get; set; }
    }
}