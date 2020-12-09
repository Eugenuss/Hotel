using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelAIS.Windows
{
    /// <summary>
    /// Interaction logic for RoomsWindow.xaml
    /// </summary>
    public partial class RoomsWindow : Window
    {
        public RoomsWindow()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void AddRoomButton_Click(object sender, RoutedEventArgs e)
        {
            Room newRoom = new Room(0,1,1,1,1,1,1);

            Window addRoomWindow = new AddRoomWindow(newRoom, this);
            addRoomWindow.Show();
        }

        public void UpdateTable()
        {
            RoomsData.ItemsSource = null;
            RoomsData.ItemsSource = XApp.downloadRooms().DefaultView;
        }

        private void DelRoomButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView selectedRoom = (DataRowView)RoomsData.SelectedItem;
                int Number = Convert.ToInt32(selectedRoom["Number"]);
                string sqlRequest = $"DELETE FROM `rooms` WHERE `rooms`.`Number` = {Number};";
                XApp.openDBConnection();
                MySqlCommand cmd = XApp.connection.CreateCommand();
                cmd.CommandText = sqlRequest;
                cmd.ExecuteNonQuery();
                XApp.closeDBConnection();
                UpdateTable();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
