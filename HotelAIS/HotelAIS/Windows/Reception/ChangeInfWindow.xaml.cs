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
            try
            {
                _index = indexSelectedRoom;
                string sql = $"select * from rooms where ID ={indexSelectedRoom};";
                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
                DataTable table = new DataTable();
                sda.Fill(table);
                connect.Close();
                ChangeData.ItemsSource = table.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int booking = Convert.ToInt32(BookingStat.Text);
                int busy = Convert.ToInt32(BusyStat.Text);
                string sql = $"update rooms set BusyStatus={busy}, BookingStatus={booking} where ID={_index};";
                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                MySqlCommand cmd = connect.conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Информация изменена", "Уведомление", MessageBoxButton.OK);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BookingFocus(object sender, RoutedEventArgs e)
        {
            if (BookingStat.Text == "Статус брони")
            {
                BookingStat.Text = "";
            }
        }

        private void BookingLost(object sender, RoutedEventArgs e)
        {
            if (BookingStat.Text == "")
            {
                BookingStat.Text = "Статус брони";
            }
            
        }
        private void BusyFocus(object sender, RoutedEventArgs e)
        {
            if (BusyStat.Text == "Занятость")
            {
                BusyStat.Text = "";
            }
            
        }
        private void BusyLost(object sender, RoutedEventArgs e)
        {
            if (BusyStat.Text == "")
            {
                BusyStat.Text = "Занятость";
            }
            
        }
        
    }
}