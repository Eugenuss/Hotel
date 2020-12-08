using System.Collections.Generic;
using System.Data;
using System.Windows;
using HotelAIS.Windows.ForDirector;
using HotelAIS.Windows.ForMaid;
using HotelAIS.Windows.Reception;
using MySql.Data.MySqlClient;


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
            UserPassword.Visibility = Visibility.Visible;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"select * from users where Login='{UserName.Text}' and Password='{UserPassword.Password}'";
            string connString = "Server=26.146.217.182;Port=3306;Database=hotel;Uid=DoomSlayer;pwd=lilboss;charset=utf8;";
            MySqlConnection connect = new MySqlConnection(connString);
            connect.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect);
            DataTable table = new DataTable();
            sda.Fill(table);
            connect.Close();



            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вход выполнен успешно! ");
                switch (table.Rows[0].ItemArray.GetValue(3).ToString())
                {
                    case "Admin":
                        Window adminMainWindow = new AdminMainWindow();
                        adminMainWindow.Owner = this;
                        this.Hide();
                        adminMainWindow.Show();
                        break;
                    case "Director":
                        Window actionsForDirector = new ActionsForDirector();
                        actionsForDirector.Owner = this;
                        this.Hide();
                        actionsForDirector.Show();
                        break;
                    case "Reception":
                        Window receptionActions = new ReceptionActions();
                        receptionActions.Owner = this;
                        this.Hide();
                        receptionActions.Show();
                        break;
                    case "Maid":
                        Window actionsForMaid = new ActionsForMaid();
                        actionsForMaid.Owner = this;
                        this.Hide();
                        actionsForMaid.Show();
                        break;
                }
            }



        }

        private void UserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UserName.Text == "Имя пользователя")
            {
                UserName.Text = "";
            }
        }

        private void UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UserName.Text == "")
            {
                UserName.Text = "Имя пользователя";
            }
        }

        private void UserPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UserPassword.Password == "Пароль")
            {
                UserPassword.Password = "";
   
            }
        }

        private void UserPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UserPassword.Password == "")
            {
                UserPassword.Password = "Пароль";
            }
        }
    }
}