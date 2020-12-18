using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAIS
{
    class XApp
    {
        public static MySqlConnection connection;

        public static void openDBConnection()
        {
            string connString = MySqlConnect.connString;
            connection = new MySqlConnection(connString);
            connection.Open();
        }

        public static void closeDBConnection()
        {
            connection.Close();
        }

        public static DataTable downloadUsers()
        {
            openDBConnection();
            string sqlRequest = $"select * from users;";
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlRequest, connection);
            DataTable table = new DataTable();
            sda.Fill(table);
            closeDBConnection();
            return table;
        }

        public static DataTable downloadRooms()
        {
            openDBConnection();
            string sqlRequest = $"select * from rooms;";
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlRequest, connection);
            DataTable table = new DataTable();
            sda.Fill(table);
            closeDBConnection();
            return table;
        }
    }
}
