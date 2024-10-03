﻿using System;
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
    /// <summary>
    /// NewGameCaution.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewGameCaution : Window
    {
        public NewGameCaution()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            var MainWIndow = new Play(true);
            ((MainWindow)Application.Current.MainWindow).mainWindow.Children.Clear();
            ((MainWindow)Application.Current.MainWindow).mainWindow.Children.Add(MainWIndow);
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
