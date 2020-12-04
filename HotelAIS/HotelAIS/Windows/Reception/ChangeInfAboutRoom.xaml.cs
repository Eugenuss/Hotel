using System.Data;
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
            string sql = "select * from rooms;";
            string connString =
                "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
            MySqlConnection connect = new MySqlConnection(connString);
            connect.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect);
            DataTable table = new DataTable();
            sda.Fill(table);
            connect.Close();
            ChangeInfData.ItemsSource = table.DefaultView;
            
        }
        
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void DoubleClick_Click(object sender, MouseButtonEventArgs e)
        {
            //TO DO
            //Get selected item and change them
        }
    }
}