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
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void RoomsButton_Clicked(object sender, RoutedEventArgs e)
        {
            Window roomsWindow = new RoomsWindow();
            roomsWindow.Owner = this;
            this.Hide();
            roomsWindow.Show();
        }

        private void ReturnButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void UserButton_Clicked(object sender, RoutedEventArgs e)
        {
            Window usersWindow = new UsersWindow();
            usersWindow.Owner = this;
            this.Hide();
            usersWindow.Show();
        }
    }
}
