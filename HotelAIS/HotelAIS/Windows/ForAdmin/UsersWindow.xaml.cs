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
            User newUser = new User(0, "", "", "");

            Window addUserWindow = new AddUserWindow(newUser, this);
            addUserWindow.Show();
        }

        public void UpdateTable()
        {
            UsersData.ItemsSource = null;
            UsersData.ItemsSource = XApp.downloadUsers().DefaultView;
        }

        private void DelUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView selectedUser = (DataRowView)UsersData.SelectedItem;
                int id = Convert.ToInt32(selectedUser["ID"]);
                string sqlRequest = $"DELETE FROM `users` WHERE `users`.`ID` = {id}";
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
