using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using HotelAIS.Windows.Reception;

namespace HotelAIS
{
    public partial class ChangeInfWindow : Window
    {
        private int _index;
        public ChangeInfWindow(int indexSelectedRoom)
        {
            InitializeComponent();
            _index = indexSelectedRoom;
            string sql = $"select * from rooms where ID ={indexSelectedRoom};";
            string connString =
                "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
            MySqlConnection connect = new MySqlConnection(connString);
            connect.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect);
            DataTable table = new DataTable();
            sda.Fill(table);
            connect.Close();
            ChangeData.ItemsSource = table.DefaultView;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int booking = Convert.ToInt32(BookingStat.Text);
            int busy = Convert.ToInt32(BusyStat.Text);
            string sql = $"update rooms set BusyStatus={busy}, BookingStatus={booking} where ID={_index};";
            string connString = "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Информация изменена", "Уведомление", MessageBoxButton.OK);
            
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}