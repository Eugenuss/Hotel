using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace HotelAIS.Windows.Reception
{
    public partial class ChangeInfAboutGuest : Window
    {
        private DataRowView selectedGuest;
        
        public ChangeInfAboutGuest()
        {
            InitializeComponent();
            UpdateTable();
        }
        
        private void ReturnBut_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void ChangeInf_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRoom = (DataRowView)GuestsData.SelectedItem;
            String valueOfItem = selectedRoom["ID"].ToString();
            //GuestsData_OnCurrentCellChanged();
        }

        private void UpdateTable()
        {
            string sql = "select * from guests;";
            MySqlConnect connect = new MySqlConnect();
            connect.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
            DataTable table = new DataTable();
            sda.Fill(table);
            connect.Close();
            GuestsData.ItemsSource = table.DefaultView;
        }

        private void GuestsData_OnCurrentCellChanged(object sender, EventArgs e)
        {
            selectedGuest = (DataRowView)GuestsData.SelectedItem;
            if (selectedGuest != null)
            {
                int index = Convert.ToInt32(selectedGuest["ID"].ToString());
                String Fname = selectedGuest["FirstName"].ToString();
                String Sname = selectedGuest["SecondName"].ToString();
                String Mname = selectedGuest["MiddleName"].ToString();
                int Seria = Convert.ToInt32(selectedGuest["Seria"].ToString());
                int Nomer = Convert.ToInt32(selectedGuest["Nomer"].ToString());
            
                string sql = $"update guests set FirstName='{Fname}', SecondName='{Sname}', MiddleName='{Mname}'," +
                             $"Seria={Seria}, Nomer={Nomer} where ID={index};";
                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                MySqlCommand cmd = connect.conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                connect.Close();
                UpdateTable(); 
            }
        }
        private void DeleteGuest_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                int index = Convert.ToInt32(selectedGuest["ID"]);
                string sql = $"DELETE FROM `guests` WHERE `guests`.`ID` = {index};";
                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                MySqlCommand cmd = connect.conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                connect.Close();
                UpdateTable();
                
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