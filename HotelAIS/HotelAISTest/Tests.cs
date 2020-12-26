using System;
using System.Data;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace HotelAISTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string sql = "select * from guests;";
            MySQLConnection connect = new MySQLConnection();
            connect.conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
            DataTable table = new DataTable();
            sda.Fill(table);
            connect.conn.Close();
            string nameGuest = table.Rows[1].ItemArray.GetValue(1).ToString();        // 4 и 2
            
            string sqlStud = "select * from hotelhistory;";
            connect.conn.Open();
            MySqlDataAdapter sdaStud = new MySqlDataAdapter(sqlStud, connect.conn);
            DataTable tableStud = new DataTable();
            sdaStud.Fill(tableStud);
            connect.conn.Close();
            string nameGuestFromTable = tableStud.Rows[1].ItemArray.GetValue(1).ToString();       //3 и 1
            
            Assert.AreEqual(nameGuest,nameGuestFromTable );
        }
    }

    public class MySQLConnection
    {
        public static string connString =
            "Server=localhost;Port=3306;Database=hotel;Uid=mysql;pwd=mysql;charset=utf8;";
        // "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
        public MySqlConnection conn = new MySqlConnection(connString);
    }
}