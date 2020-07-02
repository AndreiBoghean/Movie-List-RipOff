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
            dynamic details = ApiMethods.GetItemFromApi(type, id);
            
            switch (type)
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

                    if ((string)details.deathday != null) { TextBlock3.Text = "dead: " + (string)details.deathday; }
                    else { TextBlock3.Text = "dead: not yet."; } break;
            }

            if (type != "person")
            {
                dynamic credits = ApiMethods.GetItemFromApi(type, id, "/credits");

                foreach (var person in credits.cast)
                {
                    BitmapImage image = new BitmapImage(new Uri(@"https://www.praxisemr.com/images/testimonials_images/dr_profile.jpg"));

                    if ((string)person.profile_path != null)
                    { image = ApiMethods.GetImage((string)person.profile_path, "w400"); }

                    CastStackPanel.Children.Add(new
                        PersonCard(
                        frame: frame,
                        id: (string)person.id,
                        type: "person",
                        img: image,
                        field1: (string)person.name,
                        field3: (string)person.character
                        ));
                }
                foreach (var person in credits.crew)
                {
                    BitmapImage image = new BitmapImage(new Uri(@"https://www.praxisemr.com/images/testimonials_images/dr_profile.jpg"));

                    if ((string)person.profile_path != null)
                    { image = ApiMethods.GetImage((string)person.profile_path, "w400"); }

                    CrewStackPanel.Children.Add(new PersonCard(
                        frame: frame,
                        id: (string)person.id,
                        type: "person",
                        img: image,
                        field1: (string)person.name,
                        field2: "",
                        field3: (string)person.job
                        ));
                }

                dynamic recommendations = ApiMethods.GetItemFromApi(type, id, "/recommendations");

                foreach (var item in recommendations.results)
                {
                    RecomendationsStackPanel.Children.Add(new PersonCard(
                        frame: frame,
                        id: (string)item.id,
                        type: id,
                        img: ApiMethods.GetImage((string)item.poster_path, "w400"),
                        field1: (string)item.original_title,
                        field2: (string)item.vote_average + "/10",
                        field3: (string)item.release_date
                        ));
                }
            }
        }
    }
}
