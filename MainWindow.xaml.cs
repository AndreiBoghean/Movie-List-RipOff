using movie_list_ripoff.Controls;
using movie_list_ripoff.pages;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace movie_list_ripoff
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainContentFrame.Content = new StartupPage(MainContentFrame);
        }
    }
}