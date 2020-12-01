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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckAuth())
            {
                Window adminMainWindow = new AdminMainWindow();
                adminMainWindow.Owner = this;
                this.Hide();
                adminMainWindow.Show();
            }
        }

        public bool CheckAuth()
        {
            foreach (User u in XApp.users)
            {
                if (u.login == UserName.Text)
                {
                    if (u.password == UserPassword.Text)
                    {
                        if (u.role == "admin")
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
