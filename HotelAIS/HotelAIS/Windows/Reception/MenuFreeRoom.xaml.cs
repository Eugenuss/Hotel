using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace HotelAIS.Windows.Reception
{
    public partial class MenuFreeRoom : Window
    {
        private List<Room> freeRoom = new List<Room>(); 
        
        public MenuFreeRoom()
        {
            InitializeComponent();
            try
            {
                string sql = "select * from rooms where BusyStatus=0 and BookingStatus=0;";
            
                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
                DataTable table = new DataTable();
                sda.Fill(table);
                connect.Close();
                RoomsFreeData.ItemsSource = table.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
        private void LoginWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Process.Start("Manual.pdf");
            }
        }
    }
}