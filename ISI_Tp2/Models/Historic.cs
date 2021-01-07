using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISI_Tp2.Models
{
    public class Historic
    {
        public int IdHistoric { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int TrackId { get; set; }
    }
}
