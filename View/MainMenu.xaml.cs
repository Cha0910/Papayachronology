using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace 파파야연대기.View
{
    /// <summary>
    /// MainMenu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void NewAdventureButton_Click(object sender, RoutedEventArgs e)
        {
            if(SaveService.SaveService.isFileExists())
            {
                NewGameCaution newGameCaution = new NewGameCaution();
                newGameCaution.Owner = Application.Current.MainWindow;
                newGameCaution.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                newGameCaution.ShowDialog();
            }

            else
            {
                Play MainWIndow = new Play(true);
                ((MainWindow)Application.Current.MainWindow).mainWindow.Children.Clear();
                ((MainWindow)Application.Current.MainWindow).mainWindow.Children.Add(MainWIndow);
            }
            
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            if (!SaveService.SaveService.isFileExists())
            {
                NoticeWindow noticeWindow = new NoticeWindow("저장된 기록이 없습니다.");
                noticeWindow.Owner = Application.Current.MainWindow;
                noticeWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                noticeWindow.ShowDialog();
            }

            else
            {
                Play MainWIndow = new Play(false);
                ((MainWindow)Application.Current.MainWindow).mainWindow.Children.Clear();
                ((MainWindow)Application.Current.MainWindow).mainWindow.Children.Add(MainWIndow);
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Close();
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            var settingWindow = new SettingWindow();
            settingWindow.Owner = Application.Current.MainWindow;
            settingWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settingWindow.ShowDialog();
        }     
    }
}
