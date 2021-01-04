using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RockPaperScissorsGame;

namespace RockPaperScissorsGUI
{
    /// <summary>
    /// Interaction logic for RockPaperScissorsWindow.xaml
    /// </summary>
    public partial class RockPaperScissorsWindow : Window
    {
        GameLoop gl = new GameLoop();
        public RockPaperScissorsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gl.StartUp(NameBox.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gl.PlayerRock();
        }
    }
}
