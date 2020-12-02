using System.Windows;
using System.Windows.Controls;
using Geared.Wpf.Scrollable;

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
            // UserControl statisticMoney = new StatisticMoney();
            // statisticMoney.IsEnabled = false;

        }

        private void StatisticGuestsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void StatisticFreeRoomBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}