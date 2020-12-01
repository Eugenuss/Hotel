using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAIS
{
    public class User
    {
        public User(int id, string login, string password, string role)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.role = role;
        }

        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
