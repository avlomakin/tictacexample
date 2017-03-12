﻿using System.Windows;

namespace SuperTic.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HotSeat_Click(object sender, RoutedEventArgs e)
        {
            new View.HotSeatView().Show();
        }
    }
}
