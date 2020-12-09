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
            try
            {
                List<Room> result = new List<Room>();
            
                string sql = "select Number,CleanStatus from rooms where CleanStatus=0;";
                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
                DataTable table = new DataTable();
                sda.Fill(table);
                connect.Close();
            
                RoomsData.ItemsSource = table.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ReturnButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}