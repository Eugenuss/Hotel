using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace HotelAIS.Windows.Reception
{
    public partial class ChangeInfAboutRoom : Window
    {
        public ChangeInfAboutRoom()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Owner.Show();
            this.Close();
        }

        private void ChangeInfAbout_Click(object sender, RoutedEventArgs e)
        {
            int index = 0; //Костыль
            try
            {
                DataRowView selectedRoom = (DataRowView)ChangeInfData.SelectedItem;
                String valueOfItem = selectedRoom["ID"].ToString();
                index = Convert.ToInt32(valueOfItem);
                Window changeInfWindow = new ChangeInfWindow(index);
                //changeInfWindow.Owner = this;
                changeInfWindow.Show();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Вы не выбрали комнату!", "Уведомление", MessageBoxButton.OK);
            }

        }

        public void UpdateTable()
        {
            string sql = "select * from rooms;";
            MySqlConnect connect = new MySqlConnect();
            connect.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
            DataTable table = new DataTable();
            sda.Fill(table);
            connect.Close();
            ChangeInfData.ItemsSource = table.DefaultView;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateTable();
                MessageBox.Show("Данные обновлены!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
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