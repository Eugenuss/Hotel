using System.Windows;


namespace HotelAIS.Windows.ForMaid
{
    public partial class ActionsForMaid : Window
    {
        public ActionsForMaid()
        {
            InitializeComponent();
        }
        
        

        private void CleanBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void NeedCleanBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ShowDirtRoom_OnClick(object sender, RoutedEventArgs e)
        {
            Window needCleanRooms = new NeedCleanRooms();
            needCleanRooms.Owner = this;
            needCleanRooms.Show();
            
        }

        private void ReturnButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        
    }
}