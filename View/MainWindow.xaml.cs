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
using 파파야연대기.ViewModel;

namespace 파파야연대기.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MediaPlayer BgmPlayer = new MediaPlayer();
        public static MediaPlayer SePlayer = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            BgmPlayer.Open(new Uri(@"Resources/Musics/MainMenuBgm.wav" ,UriKind.RelativeOrAbsolute));
            BgmPlayer.MediaEnded += new EventHandler(Bgm_Ended);
            BgmPlayer.Volume = 0.5;
            BgmPlayer.Play();

            SePlayer.Volume = 0.5;
            
            var MainWIndow = new View.MainMenu();
            mainWindow.Children.Add(MainWIndow);  
        }

        private void Bgm_Ended(object sender, EventArgs e)
        {
            BgmPlayer.Position = TimeSpan.Zero;
            BgmPlayer.Play();
        }

        public static void PlaySEUri(string uri)
        {
            SePlayer.Open(new Uri(uri, UriKind.RelativeOrAbsolute));
            SePlayer.Play();
        }

    }
}
