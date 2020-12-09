using MySql.Data.MySqlClient;

namespace HotelAIS
{
    public class MySqlConnect
    {
        public static string connString =
            "Server=localhost;Port=3306;Database=hotel;Uid=mysql;pwd=mysql;charset=utf8;";
        public MySqlConnection conn = new MySqlConnection(connString);

        public void Open()
        {
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }
    }
}