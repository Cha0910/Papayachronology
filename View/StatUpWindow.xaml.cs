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
using System.Windows.Shapes;
using 파파야연대기.ViewModel;

namespace 파파야연대기.View
{
    /// <summary>
    /// StatUpWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatUpWindow : Window
    {
        int statPoint;
        public GameSession Session => DataContext as GameSession;
        public StatUpWindow()
        {
            InitializeComponent();
            statPoint = 5;
            RemainingPointsTextBlock.Text = statPoint.ToString();
        }

        private void StatUpButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender == StrengthButton)
            {
                Session.player.Strength++;
            }

            else if(sender == DexterityButton)
            {
                Session.player.Dexterity++;
            }

            else if(sender == StaminaButton)
            {
                Session.player.Stamina++;
            }

            else if(sender == IntelligenceButton)
            {
                Session.player.Intelligence++;
            }

            else if(sender == WizdomButton)
            {
                Session.player.Wizdom++;
            }

            else if(sender == CharmButton)
            {
                Session.player.Charm++;
            }

            else
            {
                statPoint++;
            }

            statPoint--;

            if(statPoint == 0)
            {
                StrengthButton.IsEnabled = false;
                DexterityButton.IsEnabled = false;
                StaminaButton.IsEnabled = false;
                IntelligenceButton.IsEnabled = false;
                WizdomButton.IsEnabled = false;
                CharmButton.IsEnabled = false;
            }

            RemainingPointsTextBlock.Text = statPoint.ToString();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
