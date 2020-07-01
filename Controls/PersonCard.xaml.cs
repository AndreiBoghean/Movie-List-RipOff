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
    public partial class PersonCard : UserControl
    {
        public PersonCard(BitmapImage img, string field1 = "NAME NOT FOUND", string field2 = "as", string field3 = "ROLE NOT FOUND")
        {
            InitializeComponent();
            image.Source = img;
            TextBlock1.Text = field1;
            TextBlock2.Text = field2;
            TextBlock3.Text = field3;
        }
    }
}
