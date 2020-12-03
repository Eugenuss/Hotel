using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace HotelAIS.Windows.ForMaid
{
    public partial class NeedCleanRooms : Window
    {
        public NeedCleanRooms()
        {
            InitializeComponent();
            // string sql = "select * from users where Login=\""+UserPassword.Text+"\" and Password=\""+UserPassword.Text+"\"";
            // string connString = "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
            // MySqlConnection connect = new MySqlConnection(connString);
            // connect.Open();
            // MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect);
            // DataTable table = new DataTable();
            // sda.Fill(table);
            // connect.Close();

        }

        private void ReturnButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}