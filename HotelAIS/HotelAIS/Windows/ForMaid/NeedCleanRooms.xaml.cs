using System.Windows;

namespace HotelAIS.Windows.ForMaid
{
    public partial class NeedCleanRooms : Window
    {
        public NeedCleanRooms()
        {
            InitializeComponent();
        }

        private void ReturnButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}