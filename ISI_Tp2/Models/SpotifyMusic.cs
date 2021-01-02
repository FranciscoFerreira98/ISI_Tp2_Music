using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISI_Tp2.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Artist
    {
        public string name { get; set; }
    }

    public class ExternalUrls
    {
        public string spotify { get; set; }
    }

    public class Image
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Album
    {
        public List<Artist> artists { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
    }

    public class Item
    {
        public Album album { get; set; }
        public string name { get; set; }
    }

    public class Tracks
    {
        public string href { get; set; }
        public List<Item> items { get; set; }
    }

    public class SpotifyMusic 
    {
        public Tracks tracks { get; set; }
    }


}
