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
                if (CurCol >= 8)
                {
                    CurCol = 0;
                    Results_Grid.RowDefinitions.Add(new RowDefinition());
                    CurRow++;
                }

                return CurCol++;
            }
        }

        int CurRow = 0;
        private int CurrentRow
        {
            get { return CurRow; }
        }

        public SearchPage(Frame frame, string SearchParam)
        {
            InitializeComponent();
            Results_Grid.RowDefinitions.Add(new RowDefinition());

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
                        Movie_Card.Margin = new Thickness(5);
                        Movie_Card.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3c366b"));
                        AddToGrid(Movie_Card, CurrentColumn, CurrentRow);
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
                        Tv_Card.Margin = new Thickness(5);
                        Tv_Card.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3c366b"));
                        AddToGrid(Tv_Card, CurrentColumn, CurrentRow);
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
                        person_Card.Margin = new Thickness(5);
                        person_Card.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3c366b"));
                        AddToGrid(person_Card, CurrentColumn, CurrentRow);
                        break;
                }
                Console.WriteLine(Results_Grid.Children.Count);
            }
        }
        void AddToGrid(UIElement element, int column, int row)
        {
            Grid.SetColumn(element, column);
            Grid.SetRow(element, row);
            Results_Grid.Children.Add(element);
        }
    }
}