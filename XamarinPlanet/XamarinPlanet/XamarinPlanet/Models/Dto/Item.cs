using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Item
    {
        private string description;

        public Guid Guid { get; set; }
        public string Link { get; set; }
        public object Category { get; set; }
        public object Title { get; set; }
        public DateTime PubDate { get; set; }
        [JsonProperty("dc:creator")]
        public Creator Creator { get; set; }
        [JsonProperty("content:encoded")]
        public Encoded Encoded { get; set; }
        [JsonProperty("post-id")]
        public PostId PostId { get; set; }
        public string Description
        {
            get => $@"<html>
<body>{description}</body>
</html>";
            set => description = value;
        }
        public CommentRss CommentRss { get; set; }
        [JsonProperty("yt:videoId")]
        public VideoId VideoId { get; set; }
        [JsonProperty("yt:channelId")]
        public ChannelId ChannelId { get; set; }
        [JsonProperty("media:group")]
        public Group Group { get; set; }
        [JsonProperty("itunes:subtitle")]
        public Subtitle Subtitle { get; set; }
        [JsonProperty("itunes:duration")]
        public Duration Duration { get; set; }
        [JsonProperty("itunes:explicit")]
        public Explicit Explicit { get; set; }
        [JsonProperty("itunes:image")]
        public Image Image { get; set; }
        [JsonProperty("podcast:transcript")]
        public Transcript Transcript { get; set; }
        [JsonProperty("itunes:keywords")]
        public Keywords Keywords { get; set; }
        [JsonProperty("itunes:summary")]
        public Summary Summary { get; set; }
        public List<Person> Person { get; set; }
        public List<Tag> Tag { get; set; }
        [JsonProperty("dc:publisher")]
        public Publisher Publisher { get; set; }
        [JsonProperty("pingback:server")]
        public Server Server { get; set; }
        [JsonProperty("pingback:target")]
        public Target Target { get; set; }
        [JsonProperty("trackback:ping")]
        public Ping Ping { get; set; }
        [JsonProperty("wfw:comment")]
        public Comment Comment { get; set; }
        [JsonProperty("a10:content")]
        public object Content { get; set; }
        [JsonProperty("media:thumbnail")]
        public Thumbnail Thumbnail { get; set; }
        [JsonProperty("thr:total")]
        public Total Total { get; set; }
        [JsonProperty("podcast:chapters")]
        public Chapters Chapters { get; set; }
    }
}