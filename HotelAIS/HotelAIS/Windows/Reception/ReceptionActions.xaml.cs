using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

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
        private void LoginWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Process.Start("Manual.pdf");
            }
        }
    }
}