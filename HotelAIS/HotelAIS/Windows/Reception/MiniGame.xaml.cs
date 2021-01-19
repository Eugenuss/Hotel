using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HotelAIS.Windows.Reception
{
    public partial class MiniGame : Window
    {
        private Random rand = new Random();

        public MiniGame()
        {
            InitializeComponent();
            
        }
        
        private int chet = 0;
        private void MouseDown_Click(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetLeft(theEll, rand.Next(0, Convert.ToInt32(CanvasGame.Width)));
            Canvas.SetTop(theEll, rand.Next(0, Convert.ToInt32(CanvasGame.Height) - 100));
            
            ++chet;
        }
        
    }
}