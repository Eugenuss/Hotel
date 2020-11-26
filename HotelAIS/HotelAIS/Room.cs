using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAIS
{
    public class Room
    {
        public Room(int id, string status, DateTime rateEndTime)
        {
            this.id = id;
            this.status = status;
            this.rateEndTime = rateEndTime;
        }

        public int id { get; set; }
        public string status { get; set; }
        public DateTime rateEndTime { get; set; }
    }
}
