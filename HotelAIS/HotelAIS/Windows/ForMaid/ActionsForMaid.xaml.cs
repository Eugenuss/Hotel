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
                if (NumberField.Text != "" || NumberField.Text != "Номер комнаты")
                {
                    string sql = "UPDATE `rooms` Set `CleanStatus`=1 WHERE ID=" + Convert.ToInt32(NumberField.Text);
                    MySqlConnect connect = new MySqlConnect();
                    connect.Open();
                    MySqlCommand cmd = connect.conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Комната " + NumberField.Text + " отмечена как убранная!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void NeedCleanBtn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "UPDATE `rooms` Set `CleanStatus`=0 WHERE ID=" + Convert.ToInt32(NumberField.Text);


                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                MySqlCommand cmd = connect.conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Комната " + NumberField.Text + " отмечена как НЕубранная!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
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
            Window login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}