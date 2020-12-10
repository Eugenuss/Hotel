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
            Window login = new LoginWindow();
            login.Show();
            this.Close();
        }
        
        private void FreeRoomsBut_Click(object sender, RoutedEventArgs e)
        {
            Window menuFreeRoom = new MenuFreeRoom();
            menuFreeRoom.Owner = this;
            menuFreeRoom.Show();
        }
        
        private void ChangeRoomStatBut_Click(object sender, RoutedEventArgs e)
        {
            
            Window changeInfAboutRoom = new ChangeInfAboutRoom();
            //changeInfAboutRoom.Owner = this;
            changeInfAboutRoom.Show();
        }
        
        private void AddGuestBut_Click(object sender, RoutedEventArgs e)
        {
            Window addGuest = new AddGuest();
            addGuest.Owner = this;
            addGuest.Show();
        }

        private void ChangeGuestBut_Click(object sender, RoutedEventArgs e)
        {
            Window changeInfAboutGuest = new ChangeInfAboutGuest();
            changeInfAboutGuest.Owner = this;
            changeInfAboutGuest.Show();
        }
    }
}