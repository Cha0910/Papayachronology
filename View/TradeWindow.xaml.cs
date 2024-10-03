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
    /// TradeWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TradeWindow : Window
    {
        public GameSession Session => DataContext as GameSession;
        public TradeWindow()
        {
            InitializeComponent();
            Owner = ((MainWindow)Application.Current.MainWindow);
            this.Top = Owner.Top + 200;
            this.Left = Owner.Left + 610;
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == Slot0)
                Session.trader.sellItem(0);
            else if (sender == Slot1)
                Session.trader.sellItem(1);
            else if (sender == Slot2)
                Session.trader.sellItem(2);
            else if (sender == Slot3)
                Session.trader.sellItem(3);
            else if (sender == Slot4)
                Session.trader.sellItem(4);
            else if (sender == Slot5)
                Session.trader.sellItem(5);
            else if (sender == Slot6)
                Session.trader.sellItem(6);
            else if (sender == Slot7)
                Session.trader.sellItem(7);
            else if (sender == Slot8)
                Session.trader.sellItem(8);
            else if (sender == Slot9)
                Session.trader.sellItem(9);
            else if (sender == Slot10)
                Session.trader.sellItem(10);
            else if (sender == Slot11)
               Session.trader.sellItem(11);
            else if (sender == Slot12)
                Session.trader.sellItem(12);
            else if (sender == Slot13)
                Session.trader.sellItem(13);
            else if (sender == Slot14)
                Session.trader.sellItem(14);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
