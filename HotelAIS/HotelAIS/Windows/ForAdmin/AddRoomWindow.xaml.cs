using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


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
                cmd.CommandText = sqlRequest;
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
        private void LoginWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Process.Start("Manual.pdf");
            }
        }
    }
}