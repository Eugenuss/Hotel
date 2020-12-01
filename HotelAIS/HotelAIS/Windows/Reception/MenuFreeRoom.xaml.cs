using System.Collections.Generic;
using System.Windows;

namespace HotelAIS.Windows.Reception
{
    public partial class MenuFreeRoom : Window
    {
        private List<Room> freeRoom = new List<Room>(); 
        
        public MenuFreeRoom()
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