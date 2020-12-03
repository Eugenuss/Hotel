using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;


namespace HotelAIS.Windows.ForMaid
{
    public partial class ActionsForMaid : Window
    {
        public ActionsForMaid()
        {
            InitializeComponent();
        }
        
        

        private void CleanBtn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "UPDATE `rooms` Set `CleanStatus`=0 WHERE ID="+Convert.ToInt32(NumberField.Text);
                string connString = "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Комната "+NumberField.Text+" отмечена как убранная!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                throw;
            }
        }

        private void NeedCleanBtn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "UPDATE `rooms` Set `CleanStatus`=1 WHERE ID="+Convert.ToInt32(NumberField.Text);
                string connString = "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Комната "+NumberField.Text+" отмечена как НЕубранная!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                throw;
            }
        }

        private void ShowDirtRoom_OnClick(object sender, RoutedEventArgs e)
        {
            Window needCleanRooms = new NeedCleanRooms();
            needCleanRooms.Owner = this;
            needCleanRooms.Show();
            
        }

        private void ReturnButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        
    }
}