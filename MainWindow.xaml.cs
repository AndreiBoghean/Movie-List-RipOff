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
        StartupPage startupPage;
        public MainWindow()
        {
            InitializeComponent();

            startupPage = new StartupPage(MainContentFrame);
            MainContentFrame.Content = startupPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Content = startupPage;
        }
    }
}