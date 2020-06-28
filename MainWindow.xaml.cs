using movie_list_ripoff.Controls;
using System.Windows;

namespace movie_list_ripoff
{
    public partial class MainWindow : Window
    {
        public MainWindow()
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
                    name: (string)item.original_title,
                    rating: (string)item.vote_average,
                    date: (string)item.release_date);

                PopularmoviesStackpanel.Children.Add(card);
            }
        }
    }
}