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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gl.PlayerRock();
        }

        private void NameSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            gl.StartUp(NameBox.Text);
            HideIntroInfo();
            ShowGameButtons();
        }

        private void HideIntroInfo()
        {
            IntroductionText.Visibility = Visibility.Hidden;
            IntroductionText2.Visibility = Visibility.Hidden;
            IntroductionText3.Visibility = Visibility.Hidden;
            IntroductionText4.Visibility = Visibility.Hidden;
            IntroductionText5.Visibility = Visibility.Hidden;
            IntroductionText6.Visibility = Visibility.Hidden;
            IntroductionText7.Visibility = Visibility.Hidden;
            IntroductionText8.Visibility = Visibility.Hidden;
            IntroductionText9.Visibility = Visibility.Hidden;
            NameBox.Visibility = Visibility.Hidden;
            NameSubmitButton.Visibility = Visibility.Hidden;
        }

        private void ShowGameButtons()
        {
            RockButton.Visibility = Visibility.Visible;
            PaperButton.Visibility = Visibility.Visible;
            ScissorsButton.Visibility = Visibility.Visible;
        }
    }
}
