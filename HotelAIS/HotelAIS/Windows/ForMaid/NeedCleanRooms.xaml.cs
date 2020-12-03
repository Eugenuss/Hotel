using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using MySql.Data.MySqlClient;

namespace HotelAIS.Windows.ForMaid
{
    public partial class NeedCleanRooms : Window
    {
        public NeedCleanRooms()
        {
            InitializeComponent();
            List<Room> result = new List<Room>();
            


            string sql = "select Number,CleanStatus from rooms where CleanStatus=0;";
            string connString =
                "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
            MySqlConnection connect = new MySqlConnection(connString);
            connect.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect);
            DataTable table = new DataTable();
            sda.Fill(table);
            connect.Close();
            
            RoomsData.ItemsSource = table.DefaultView;
        }

        private void ReturnButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    // public class Room
    // {
    //     public Room(int ID, int Number, int Person, int BusyStatus, int CleanStatus, int BookingStatus, int Cost)
    //     {
    //         this.ID = ID;
    //         this.Number = Number;
    //         this.Person = Person;
    //         this.BusyStatus = BusyStatus;
    //         this.CleanStatus = CleanStatus;
    //         this.BookingStatus = BookingStatus;
    //         this.Cost = Cost;
    //     }
    //
    //     public int ID { get; set; }
    //
    //     public int Number { get; set; }
    //     public int BusyStatus { get; set; }
    //     public int Person { get; set; }
    //     public int CleanStatus { get; set; }
    //     public int BookingStatus { get; set; }
    //     public int Cost { get; set; }
    // }
}