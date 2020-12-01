using System.Windows;

namespace HotelAIS.Windows.Reception
{
    public partial class ReceptionActions : Window
    {
        public ReceptionActions()
        {
            InitializeComponent();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
        
        private void FreeRoomsBut_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void ChangeRoomStatBut_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void AddGuestBut_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ChangeGuestBut_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        
        
    }
}