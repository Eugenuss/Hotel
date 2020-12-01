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
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            int newRoomId = XApp.users.Count;
            User newUser = new User(XApp.users.Count, "", "", "");
            XApp.users.Add(newUser);

            Window addUserWindow = new AddUserWindow(newUser, this);
            addUserWindow.Show();
        }

        public void UpdateTable()
        {
            UsersData.ItemsSource = null;
            UsersData.ItemsSource = XApp.users;
        }

        private void DelUserButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)UsersData.SelectedItem;
            XApp.users.Remove(selectedUser);
            UpdateTable();
        }
    }
}
