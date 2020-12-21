using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            newUser.Login = UserLoginTextBox.Text;
            newUser.Password = UserPassTextBox.Text;
            newUser.Role = RoleTextBox.Text;
            string sqlRequest = $"INSERT INTO `users` (`ID`, `Login`, `Password`, `Role`)" +
                                $" VALUES (NULL, '{newUser.Login}', '{newUser.Password}', '{newUser.Role}');";
            XApp.openDBConnection();
            MySqlCommand cmd = XApp.connection.CreateCommand();
            cmd.CommandText = sqlRequest;
            cmd.ExecuteNonQuery();
            XApp.closeDBConnection();
            ownerWin.UpdateTable();
            this.Close();
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