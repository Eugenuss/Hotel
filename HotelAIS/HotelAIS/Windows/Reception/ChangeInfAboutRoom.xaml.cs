using System.Windows;

namespace HotelAIS.Windows.Reception
{
    public partial class ChangeInfAboutRoom : Window
    {
        public ChangeInfAboutRoom()
        {
            InitializeComponent();
        }
        
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}