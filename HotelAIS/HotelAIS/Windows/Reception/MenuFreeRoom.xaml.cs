using System.Collections.Generic;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace HotelAIS.Windows.Reception
{
    public partial class MenuFreeRoom : Window
    {
        private List<Room> freeRoom = new List<Room>(); 
        
        public MenuFreeRoom()
        {
            InitializeComponent();
            string sql = "select * from rooms where BusyStatus=0 and BookingStatus=0;";
            string connString =
                "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
            MySqlConnection connect = new MySqlConnection(connString);
            connect.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect);
            DataTable table = new DataTable();
            sda.Fill(table);
            connect.Close();
            RoomsFreeData.ItemsSource = table.DefaultView;
        }
        
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}