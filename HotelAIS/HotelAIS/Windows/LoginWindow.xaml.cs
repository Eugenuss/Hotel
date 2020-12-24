using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using HotelAIS.Windows.ForDirector;
using HotelAIS.Windows.ForMaid;
using HotelAIS.Windows.Reception;
using MySql.Data.MySqlClient;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;


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
            try
            {
                string sql =
                    $"select * from users where Login='{UserName.Text}' and Password='{UserPassword.Password}'";

                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
                DataTable table = new DataTable();
                sda.Fill(table);
                connect.Close();


                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вход выполнен успешно! ", "Успех!", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);
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
                else
                {
                    MessageBox.Show("Данные введены неверно! ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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

        private void LoginWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Process.Start("Manual.pdf");
            }
        }
    }
}