using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace HotelAIS.Windows.Reception
{
    public partial class AddGuest : Window
    {
        
        public AddGuest()
        {
            InitializeComponent();
        }

        private void ReturnBut_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fname = Convert.ToString(FName.Text);
                string sname = Convert.ToString(SName.Text);
                string mname = Convert.ToString(TName.Text);
                int seria = Convert.ToInt32(Series.Text);
                int number = Convert.ToInt32(Number.Text);
                string sql = "INSERT INTO guests (FirstName, SecondName, MiddleName, Seria, Nomer) VALUES" + 
                             $" ('{fname}', '{sname}', '{mname}', {seria}, {number});";
            
                MySqlConnect conn = new MySqlConnect();
                conn.Open();
                MySqlCommand cmd = conn.conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Owner.Show();
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void NameFocus(object sender, RoutedEventArgs e)
        {
            if (FName.Text == "Имя")
            {
                FName.Text = "";
            }
        }
        private void SnameFocus(object sender, RoutedEventArgs e)
        {
            if (SName.Text == "Фамилия")
            {
                SName.Text = "";
            }
            
        }
        private void MnameFocus(object sender, RoutedEventArgs e)
        {
            if (TName.Text == "Отчество")
            {
                TName.Text = "";
            }
            
        }
        private void SeriaFocus(object sender, RoutedEventArgs e)
        {
            if (Series.Text == "Серия паспорта")
            {
                Series.Text = "";
            }
            
        }
        private void NomerFocus(object sender, RoutedEventArgs e)
        {
            if (Number.Text == "Номер паспорта")
            {
                Number.Text = "";
            }
        }

        private void NameLost(object sender, RoutedEventArgs e)
        {
            if (FName.Text == "")
            {
                FName.Text = "Имя";
            }
        }
        private void SnameLost(object sender, RoutedEventArgs e)
        {
            if (SName.Text == "")
            {
                SName.Text = "Фамилия";
            }
            
        }
        private void MnameLost(object sender, RoutedEventArgs e)
        {
            if (TName.Text == "")
            {
                TName.Text = "Отчество";
            }
            
        }
        private void SeriaLost(object sender, RoutedEventArgs e)
        {
            if (Series.Text == "")
            {
                Series.Text = "Серия паспорта";
            }
            
        }
        private void NomerLost(object sender, RoutedEventArgs e)
        {
            if (Number.Text == "")
            {
                Number.Text = "Номер паспорта";
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