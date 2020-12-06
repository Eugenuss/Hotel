using System;
using System.Windows;
using MySql.Data.MySqlClient;

namespace HotelAIS.Windows.Reception
{
    public partial class ChangeInfAboutGuest : Window
    {
        public ChangeInfAboutGuest()
        {
            InitializeComponent();
        }
        
        private void ReturnBut_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void ChangeInf_Click(object sender, RoutedEventArgs e)
        {
            string fname = Convert.ToString(FName.Text);
            string sname = Convert.ToString(SName.Text);
            string mname = Convert.ToString(TName.Text);
            int seria = Convert.ToInt32(Series.Text);
            int number = Convert.ToInt32(Number.Text);
            int id = Convert.ToInt32(this.id.Text);
            string sql = $"UPDATE guests SET FirstName='{fname}', SecondName='{sname}', MiddleName='{mname}', " +
                $"Seria={seria}, Nomer={number} WHERE ID={id}";
            string connString = "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Гость добавлен!", "Уведомление", MessageBoxButton.OK);
        }
    }
}