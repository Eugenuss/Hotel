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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        User newUser;
        UsersWindow ownerWin;

        //parameter ownerWin is temp solution
        public AddUserWindow(User newUser, UsersWindow ownerWin)
        {
            this.newUser = newUser;
            this.ownerWin = ownerWin;
            InitializeComponent();
            UserIDTextBox.Text = newUser.id.ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            newUser.id = Convert.ToInt32(UserIDTextBox.Text);
            newUser.login = UserLoginTextBox.Text;
            newUser.password = UserPassTextBox.Text;
            newUser.role = RoleTextBox.Text;

            ownerWin.UpdateTable();
            this.Close();
        }
    }
}
