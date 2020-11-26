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
    /// Interaction logic for RoomsWindow.xaml
    /// </summary>
    public partial class RoomsWindow : Window
    {
        List<Room> rooms = new List<Room>();
        public RoomsWindow()
        {
            InitializeComponent();
            rooms.Add(new Room(0, "занята", new DateTime(2020, 11, 28)));
            rooms.Add(new Room(1, "свободна", new DateTime(2020, 11, 28)));
            rooms.Add(new Room(2, "нужна уборка", new DateTime(2020, 11, 28)));
            RoomsData.ItemsSource = rooms;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
