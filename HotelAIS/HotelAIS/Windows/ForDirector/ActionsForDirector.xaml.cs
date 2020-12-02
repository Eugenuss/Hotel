

using System;
using System.Windows;
using System.Windows.Controls;
using Wpf.CartesianChart.Basic_Bars;


namespace HotelAIS.Windows.ForDirector
{
    public partial class ActionsForDirector : Window
    {
        public ActionsForDirector()
        {
            InitializeComponent();
            
        }


        private void StatisticMoneyBtn_OnClick(object sender, RoutedEventArgs e)
        { 
            Window statisticMoney = new StatisticMoney();
            statisticMoney.Owner = this;
            statisticMoney.Show();
        }

        private void StatisticGuestsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Window statisticGuests = new StatisticGuests();
            statisticGuests.Owner = this;
            statisticGuests.Show();
        }

        private void StatisticFreeRoomBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Window statisticFreeRooms = new StatisticFreeRooms();
            statisticFreeRooms.Owner = this;
            statisticFreeRooms.Show();
        }
    }
}