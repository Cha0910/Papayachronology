using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using 파파야연대기.Classes;
using 파파야연대기.Items;
using 파파야연대기.ViewModel;

namespace 파파야연대기.View
{
    /// <summary>
    /// Play.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Play : UserControl
    {
        static private GameSession gameSession;
        int Delay;

        public Play(bool isNew)
        {
            InitializeComponent();
            if(isNew)
            {               
                gameSession = new GameSession(this);
            }

            else
            {
                gameSession = SaveService.SaveService.Load(this);
            }
            
            DataContext = gameSession;
            gameSession.gameEventManager.StartEvent();
            EventTextBlockScroll.ScrollToEnd();   
        }

        #region TextAnimation...
        public void TypewriteTextblock(string textToAnimate, int delay)
        {
            ColorTextBlock.Visibility = Visibility.Hidden;
            ButtonsPanel.Visibility = Visibility.Hidden;

            Storyboard story = new Storyboard();
            Delay = textToAnimate.Length * delay;
            TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, Delay);
            story.FillBehavior = FillBehavior.HoldEnd;

            DiscreteStringKeyFrame discreteStringKeyFrame;
            StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
            stringAnimationUsingKeyFrames.Duration = new Duration(timeSpan);

            string tmp = string.Empty;
            for (int i = 0; i < textToAnimate.Length; i++)
            {
                discreteStringKeyFrame = new DiscreteStringKeyFrame();
                discreteStringKeyFrame.KeyTime = KeyTime.Paced;
                tmp += textToAnimate[i];
                discreteStringKeyFrame.Value = tmp;
                stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
            }
            Storyboard.SetTargetName(stringAnimationUsingKeyFrames, TempTextBlock.Name);
            Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(TextBlock.TextProperty));
            story.Children.Add(stringAnimationUsingKeyFrames);
            story.Completed += new EventHandler(TextStory_Completed);
            story.Begin(TempTextBlock);
        }

        private void TextStory_Completed(object sender, EventArgs e)
        {
            ColorTextBlock.Visibility = Visibility.Visible;

            if(Delay != 0)
            {
                ColorTextBlockOpacity(1000);
            }
        }

        public void ColorTextBlockOpacity(int delay)
        {
            Storyboard storyboard = new Storyboard();

            if (ColorTextBlock.Inlines.Count == 0)
            {
                delay = 1;
            }

            TimeSpan duration = new TimeSpan(0, 0, 0, 0, delay);
            storyboard.FillBehavior = FillBehavior.HoldEnd;

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0.0;
            animation.To = 1.0;
            animation.Duration = new Duration(duration);
            Storyboard.SetTargetName(animation, ColorTextBlock.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Control.OpacityProperty));
            storyboard.Children.Add(animation);
            storyboard.Completed += new EventHandler(ColorStory_Completed);
            storyboard.Begin(ColorTextBlock); 
        }

        private void ColorStory_Completed(object sender, EventArgs e)
        {
            ButtonsPanel.Visibility = Visibility.Visible;

            if (Delay != 0)
            {
                SellectButtonOpacity(500);
            }
        }

        public void SellectButtonOpacity(int delay)
        {
            Storyboard storyboard = new Storyboard();
            Delay = 0;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, delay);
            storyboard.FillBehavior = FillBehavior.HoldEnd;

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0.0;
            animation.To = 1.0;
            animation.Duration = new Duration(duration);
            Storyboard.SetTargetName(animation, ButtonsPanel.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Control.OpacityProperty));
            storyboard.Children.Add(animation);
            storyboard.Begin(ButtonsPanel);
        }

        private void EventTextBlockScroll_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Delay != 0)
            {
                TypewriteTextblock(string.Empty, 0);
                TempTextBlock.Text = gameSession.gameText.TempText;
                ColorTextBlock.Visibility = Visibility.Visible;
                ButtonsPanel.Visibility = Visibility.Visible;
            }
        }
        #endregion

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var yesNoWindow = new YesNoWindow();
            yesNoWindow.Owner = Application.Current.MainWindow;
            yesNoWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            yesNoWindow.DataContext = gameSession;
            yesNoWindow.ShowDialog();
        }

        private void selectButton1_Click(object sender, RoutedEventArgs e)
        {
            gameSession.gameEventManager.RunEvent(1);
            SaveService.SaveService.Save(gameSession);
        }

        private void selectButton2_Click(object sender, RoutedEventArgs e)
        {
            gameSession.gameEventManager.RunEvent(2);
            SaveService.SaveService.Save(gameSession);
        }

        private void selectButton3_Click(object sender, RoutedEventArgs e)
        {
            gameSession.gameEventManager.RunEvent(3);
            SaveService.SaveService.Save(gameSession);
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == Slot0)
                gameSession.player.useItem(0);
            else if (sender == Slot1)
                gameSession.player.useItem(1);
            else if (sender == Slot2)
                gameSession.player.useItem(2);
            else if (sender == Slot3)
                gameSession.player.useItem(3);
            else if (sender == Slot4)
                gameSession.player.useItem(4);
            else if (sender == Slot5)
                gameSession.player.useItem(5);
            else if (sender == Slot6)
                gameSession.player.useItem(6);
            else if (sender == Slot7)
                gameSession.player.useItem(7);
            else if (sender == Slot8)
                gameSession.player.useItem(8);
            else if (sender == Slot9)
                gameSession.player.useItem(9);
            else if (sender == Slot10)
                gameSession.player.useItem(10);
            else if (sender == Slot11)
                gameSession.player.useItem(11);
            else if (sender == Slot12)
                gameSession.player.useItem(12);
            else if (sender == Slot13)
                gameSession.player.useItem(13);
            else if (sender == Slot14)
                gameSession.player.useItem(14);
            else if (sender == Slot15)
                gameSession.player.useItem(15);
        }

        static public void TradeWindowOpen()
        {
            TradeWindow tradeWindow = new TradeWindow();
            tradeWindow.DataContext = gameSession;
            tradeWindow.ShowDialog();
        }

        static public void StatUpWindowOpen()
        {
            StatUpWindow statUpWindow = new StatUpWindow();
            statUpWindow.DataContext = gameSession;
            statUpWindow.Owner = Application.Current.MainWindow;
            statUpWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            statUpWindow.ShowDialog();
        }

        private void WeaponSlot_Click(object sender, RoutedEventArgs e)
        {
            gameSession.player.takeOffWeapon();
        }

        private void ArmorSlot_Click(object sender, RoutedEventArgs e)
        {
            gameSession.player.takeOffArmor();
        }
    }
}
