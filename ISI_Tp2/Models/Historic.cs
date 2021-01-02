using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISI_Tp2.Models
{
    public class Historic
    {
        public long IdTrack { get; set; }
        public DateTime Date { get; set; }
        public long UserId { get; set; }
        public long TrackId { get; set; }
    }
}
