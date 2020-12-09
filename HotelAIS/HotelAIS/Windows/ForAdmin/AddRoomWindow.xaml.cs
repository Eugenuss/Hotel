using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        Room newRoom;
        RoomsWindow ownerWin;

        //parameter ownerWin is temp solution
        public AddRoomWindow(Room newRoom, RoomsWindow ownerWin)
        {
            this.newRoom = newRoom;
            this.ownerWin = ownerWin;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newRoom.Cost = Convert.ToInt32(CostTextBox.Text);
                newRoom.Number = Convert.ToInt32(RoomNumTextBox.Text);
                newRoom.Person = Convert.ToInt32(RoomPersonNumTextBox.Text);
                string sqlRequest = $"INSERT INTO `rooms` (`ID`, `Number`, `Person`, `BusyStatus`, `CleanStatus`, " +
                                    $"`BookingStatus`, `Cost`) VALUES (NULL, '{newRoom.Number}', '{newRoom.Person}'," +
                                    $" '{newRoom.BusyStatus}', '{newRoom.CleanStatus}', '{newRoom.BookingStatus}', '{newRoom.Cost}');";
                XApp.openDBConnection();
                MySqlCommand cmd = XApp.connection.CreateCommand();
                cmd.CommandText= sqlRequest;
                cmd.ExecuteNonQuery();
                XApp.closeDBConnection();
                ownerWin.UpdateTable();
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
