using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAIS
{
    public class Room
    {
        public Room(int ID, int Number, int Person, int BusyStatus, int CleanStatus, int BookingStatus, int Cost)
        {
            this.ID = ID;
            this.Number = Number;
            this.Person = Person;
            this.BusyStatus = BusyStatus;
            this.CleanStatus = CleanStatus;
            this.BookingStatus = BookingStatus;
            this.Cost = Cost;
        }

        public int ID { get; set; }
        
        public int Number { get; set; }
        public int BusyStatus { get; set; }
        public int Person { get; set; }
        public int CleanStatus { get; set; }
        public int BookingStatus { get; set; }
        public int Cost { get; set; }
    }
}
