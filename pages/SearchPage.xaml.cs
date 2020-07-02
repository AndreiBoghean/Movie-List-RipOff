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
using System.Windows.Shapes;

namespace movie_list_ripoff.pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        int CurCol = 0;
        private int CurrentColumn
        {
            get
            {
                if (CurCol >= 9)
                {
                    Results_Grid.RowDefinitions.Add(new RowDefinition());
                    CurCol = 0;
                }
                return CurCol++;
            }
            set { CurCol = value; }
        }

        int CurRow = 0;
        private int CurrentRow
        {
            get { return CurRow; }
            set { CurRow = value; }
        }

        public SearchPage(Frame frame, string SearchParam)
        {
            InitializeComponent();

            var SearchResults = ApiMethods.SearchFor(SearchParam);
            foreach (var result in SearchResults.results)
            {
                switch ((string)result.media_type)
                {
                    case ("movie"):
                        BitmapImage Movie_Image = ApiMethods.GetImage((string)result.poster_path, "w400");

                        PersonCard Movie_Card = new PersonCard(
                            frame: frame,
                            id: (string)result.id,
                            type: "movie",
                            img: Movie_Image,
                            field1: (string)result.original_title,
                            field2: "rating:",
                            field3: (string)result.vote_average
                            );
                        Grid.SetColumn(Movie_Card, CurrentColumn);
                        Grid.SetColumn(Movie_Card, CurrentRow);
                        Results_Grid.Children.Add(Movie_Card);
                        break;
                    case ("tv"):
                        BitmapImage TV_Image = ApiMethods.GetImage((string)result.backdrop_path, "w400");

                        PersonCard Tv_Card = new PersonCard(
                            frame: frame,
                            id: (string)result.id,
                            type: "movie",
                            img: TV_Image,
                            field1: (string)result.name,
                            field2: "rating:",
                            field3: (string)result.vote_average
                            );
                        Grid.SetColumn(Tv_Card, CurrentColumn);
                        Grid.SetColumn(Tv_Card, CurrentRow);
                        Results_Grid.Children.Add(Tv_Card);
                        break;
                    case ("person"):
                        BitmapImage DefaultImage = new BitmapImage(new Uri(@"https://www.praxisemr.com/images/testimonials_images/dr_profile.jpg"));
                        if ((string)result.profile_path != null)
                        { DefaultImage = ApiMethods.GetImage((string)result.profile_path, "w400"); }

                        PersonCard person_Card = new PersonCard(
                            frame: frame,
                            id: (string)result.id,
                            type: "person",
                            img: DefaultImage,
                            field1: (string)result.name,
                            field2: "Known for:",
                            field3: (string)result.known_for_department
                            );
                        Grid.SetColumn(person_Card, CurrentColumn);
                        Grid.SetColumn(person_Card, CurrentRow);
                        Results_Grid.Children.Add(person_Card);
                        break;
                }
                Console.WriteLine(Results_Grid.Children.Count);
            }
        }
    }
}