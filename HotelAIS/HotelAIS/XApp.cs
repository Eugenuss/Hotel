using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAIS
{
    class XApp
    {
        public static List<User> users = new List<User>()
        {
            new User(0, "admin", "admin", "admin")
        };

        public static List<Room> rooms = new List<Room>();
    }
}
