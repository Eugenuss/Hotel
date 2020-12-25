using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace HotelAIS.Windows.Reception
{
    public partial class ChangeInfAboutGuest : Window
    {
        private DataRowView currentGuest;

        public ChangeInfAboutGuest()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void ReturnBut_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void ChangeInf_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRoom = (DataRowView) GuestsData.SelectedItem;
            String valueOfItem = selectedRoom["ID"].ToString();
            //GuestsData_OnCurrentCellChanged();
        }

        private void UpdateTable()
        {
            string sql = "select * from guests;";
            MySqlConnect connect = new MySqlConnect();
            connect.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
            DataTable table = new DataTable();
            sda.Fill(table);
            connect.Close();
            GuestsData.ItemsSource = table.DefaultView;
        }

        private void GuestsData_OnCurrentCellChanged(object sender, EventArgs e)
        {
            MySqlConnect connect = new MySqlConnect();
            connect.Open();

            for (int i = 0; i < GuestsData.Items.Count; i++)
            {
                try
                {
                    currentGuest = GuestsData.Items[i] as DataRowView;
                    int index = Convert.ToInt32(currentGuest["ID"].ToString());
                    String fname = currentGuest["FirstName"].ToString();
                    String sname = currentGuest["SecondName"].ToString();
                    String mname = currentGuest["MiddleName"].ToString();
                    int seria = Convert.ToInt32(currentGuest["Seria"].ToString());
                    int nomer = Convert.ToInt32(currentGuest["Nomer"].ToString());
                    int room = Convert.ToInt32(currentGuest["Room"].ToString());
                    string sql = $"update guests set FirstName='{fname}', SecondName='{sname}', MiddleName='{mname}'," +
                                 $"Seria={seria}, Nomer={nomer}, Room={room} where ID={index};";
                    connect.Command(sql);
                }
                catch (Exception exception)
                {
                    // MessageBox.Show(exception.Message);
                }
            }

            connect.Close();
            UpdateTable();
        }

        private void DeleteGuest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(currentGuest["ID"]);
                string sql = $"DELETE FROM `guests` WHERE `guests`.`ID` = {index};";
                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                MySqlCommand cmd = connect.conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                connect.Close();
                UpdateTable();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Сначала выберите строку!", "Уведомление", MessageBoxButton.OK);
            }
        }

        private void LoginWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Process.Start("Manual.pdf");
            }
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            UpdateTable();
        }
    }
}