using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAIS
{
    public class Room
    {
        public Room(int id)
        {
            this.id = id;

            this.personCount = 1;
            this.cost = 0;
            busyStatus = "свободна";
            cleanStatus = "прибрана";
            bookingStatus = "незабронирована";
        }

        public int id { get; set; }
        public string busyStatus { get; set; }
        public int personCount { get; set; }
        public string cleanStatus { get; set; }
        public string bookingStatus { get; set; }
        public int cost { get; set; }
    }
}
