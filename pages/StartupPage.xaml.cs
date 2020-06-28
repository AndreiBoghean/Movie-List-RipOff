using movie_list_ripoff.Controls;
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

namespace movie_list_ripoff.pages
{
    /// <summary>
    /// Interaction logic for StartupPage.xaml
    /// </summary>
    public partial class StartupPage : Page
    {
        public StartupPage()
        {
            InitializeComponent();
            var movie = ApiMethods.GetItemFromApi("movie", "popular");

            foreach (var item in movie.results)
            {
                MovieCard card = new MovieCard(
                    image: ApiMethods.GetImage((string)item.poster_path, "w500"),
                    name: (string)item.original_title,
                    rating: (string)item.vote_average,
                    date: (string)item.release_date);

                PopularmoviesStackpanel.Children.Add(card);
            }

            var tvshows = ApiMethods.GetItemFromApi("tv", "popular");
            foreach (var item in tvshows.results)
            {
                MovieCard card = new MovieCard(
                    image: ApiMethods.GetImage((string)item.poster_path, "w500"),
                    name: (string)item.original_name,
                    rating: (string)item.vote_average,
                    date: (string)item.first_air_date);

                PopulaTVshowsStackpanel.Children.Add(card);
            }
        }
    }
}
