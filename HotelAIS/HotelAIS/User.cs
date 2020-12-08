using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAIS
{
    public class User
    {
        public User(int ID, string Login, string Password, string Role)
        {
            this.ID = ID;
            this.Login = Login;
            this.Password = Password;
            this.Role = Role;
        }

        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
