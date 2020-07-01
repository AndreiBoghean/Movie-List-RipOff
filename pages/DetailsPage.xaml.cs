using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class DetailsPage : Page
    {
        public DetailsPage(Frame frame, string id, string type)
        {
            InitializeComponent();
            //var details = ApiMethods.GetItemFromApi(type, id);
            var details = ApiMethods.GetItemFromApi("person", "6384");

            switch ("person")
            {
                case("movie"):
                    title.Text = (string)details.title;
                    image.Source = ApiMethods.GetImage( (string)details.poster_path, "w780");
                    description.Text = (string)details.overview;
                    TextBlock1.Text = "budget: " + (string)details.budget;
                    TextBlock2.Text = "runtime: " + (string)details.runtime;
                    TextBlock3.Text = "rating: " + (string)details.vote_average + "/10";
                    break;
                case ("tv"):
                    title.Text = (string)details.name;
                    image.Source = ApiMethods.GetImage((string)details.poster_path, "w780");
                    description.Text = (string)details.overview;
                    TextBlock1.Text = "episodes: " + (string)details.number_of_episodes;
                    TextBlock2.Text = "runtime: " + (string)details.episode_run_time[0];
                    TextBlock3.Text = "rating: " + (string)details.vote_average + "/10";
                    break;
                case ("person"):
                    title.Text = (string)details.name;
                    image.Source = ApiMethods.GetImage((string)details.profile_path, "w780");
                    description.Text = (string)details.biography;
                    TextBlock1.Text = "born in: " + (string)details.place_of_birth;
                    TextBlock2.Text = "birth date: " + (string)details.birthday;

                    if ( (string)details.deathday != "")
                    { TextBlock3.Text = "dead: " + (string)details.deathday; }
                    else
                    { TextBlock3.Text = "dead: not yet."; }
                    break;
            }
        }
    }
}
