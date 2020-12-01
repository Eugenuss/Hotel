using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace HotelAIS.Windows.Reception
{
    public partial class AddGuest : Window
    {
        
        public AddGuest()
        {
            InitializeComponent();
            
        }

        private void ReturnBut_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Гость добавлен!", "Уведомление", MessageBoxButton.OK);
        }
        
    }
}