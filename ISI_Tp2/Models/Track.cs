using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ISI_Tp2.Models
{
    public class Track
    {

        public int IdTrack { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string SpotifyId { get; set; }
        public string SpotifyUrl { get; set; }
        public string YoutubeId { get; set; }
        public string YoutubeUrl { get; set; }

    }
}
