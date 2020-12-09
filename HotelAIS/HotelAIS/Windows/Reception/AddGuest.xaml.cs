using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
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
                string sql = "INSERT INTO `guests` (FirstName, SecondName, MiddleName, Seria, Nomer) VALUES" + 
                             $" ('{fname}', '{sname}', '{mname}', {seria}, {number});";
            
                MySqlConnect conn = new MySqlConnect();
                conn.Open();
                MySqlCommand cmd = conn.conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Гость добавлен!", "Уведомление", MessageBoxButton.OK);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        
    }
}