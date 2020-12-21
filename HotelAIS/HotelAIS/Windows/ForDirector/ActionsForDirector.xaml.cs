using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf.CartesianChart.Basic_Bars;


namespace HotelAIS.Windows.ForDirector
{
    public partial class ActionsForDirector : Window
    {
        public DateTime dateFrom =  DateTime.Today;
        public DateTime dateTo = DateTime.Today;

        public ActionsForDirector()
        {
            InitializeComponent();
        }


        private void StatisticMoneyBtn_OnClick(object sender, RoutedEventArgs e)
        {
            GetDates();
            Window statisticMoney = new StatisticMoney(dateFrom, dateTo);
            statisticMoney.Owner = this;
            statisticMoney.Show();
        }

        private void StatisticGuestsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            GetDates();
            Window statisticGuests = new StatisticGuests(dateFrom, dateTo);
            statisticGuests.Owner = this;
            statisticGuests.Show();
        }

        private void StatisticFreeRoomBtn_OnClick(object sender, RoutedEventArgs e)
        {
            GetDates();
            Window statisticFreeRooms = new StatisticFreeRooms(dateFrom, dateTo);
            statisticFreeRooms.Owner = this;
            statisticFreeRooms.Show();
        }

        void GetDates()
        {
            if (CalendarTo.SelectedDate != null) dateTo = (DateTime) CalendarTo.SelectedDate;
            if (CalendarFrom.SelectedDate != null) dateFrom = (DateTime) CalendarFrom.SelectedDate;
        }
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Window login = new LoginWindow();
            login.Show();
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