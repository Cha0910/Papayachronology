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

namespace 파파야연대기.View
{
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
            BGMVolumeSlider.Value = ((MainWindow)System.Windows.Application.Current.MainWindow).BgmPlayer.Volume;
            SEVolumeSlider.Value = View.MainWindow.SePlayer.Volume;
        }

        private void BgmVolumeSlider_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).BgmPlayer.Volume = BGMVolumeSlider.Value;
        }   

        private void SEVolumeSlider_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            View.MainWindow.SePlayer.Volume = SEVolumeSlider.Value;
        }

        private void SettingWindowCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        } 
    }
}
