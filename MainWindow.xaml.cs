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

        private void Title_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Content = startupPage;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (SearchTextbox.Text == "") return;
            MainContentFrame.Content = new SearchPage(MainContentFrame, SearchTextbox.Text);
        }

        private void Corporate_click(object sender, RoutedEventArgs e)
        {

        }
    }
}