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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace movie_list_ripoff.Controls
{
    public partial class MovieCard : UserControl
    {
        Frame frame;
        string id;
        string type;
        public MovieCard(Frame frame, BitmapImage image, string type, string id = "82703", string title = "sanic the bush-hog", string rating = "6.9|6.9", string date = "6/9/420")
        {
            InitializeComponent();

            this.frame = frame;
            this.id = id;
            this.type = type;

            Image.Source = image;
            ObjectTitle.Text = title;
            Rating.Text = rating;
            ReleaseDate.Text = date;
        }
        public MovieCard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new DetailsPage(frame, id, type);
        }
    }
}