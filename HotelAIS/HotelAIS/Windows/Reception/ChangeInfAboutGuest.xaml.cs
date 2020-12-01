using System.Windows;

namespace HotelAIS.Windows.Reception
{
    public partial class ChangeInfAboutGuest : Window
    {
        public ChangeInfAboutGuest()
        {
            InitializeComponent();
        }
        
        private void ReturnBut_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void ChangeGuest_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}