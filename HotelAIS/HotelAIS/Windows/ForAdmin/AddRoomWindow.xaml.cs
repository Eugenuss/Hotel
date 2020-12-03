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
            newRoom.Cost = Convert.ToInt32(CostTextBox.Text);
            newRoom.ID = Convert.ToInt32(RoomNumTextBox.Text);
            newRoom.Person = Convert.ToInt32(RoomPersonNumTextBox.Text);
            ownerWin.UpdateTable();
            this.Close();
        }
    }
}
