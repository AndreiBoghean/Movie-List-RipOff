using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace movie_list_ripoff
{

    public static class ApiMethods
    {
        static HttpClient client = new HttpClient();
        static string key = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\apikey.txt");

        /// <summary>
        /// gets api <see cref="String"/> from https://api.themoviedb.org/3/<paramref name="category"/>/<paramref name="idOrType"/>?(API KEY + LANG) and returns dynamic class
        /// </summary>
        /// <param name="category">the item to get (movie, tv, actor)</param>
        /// <param name="idOrType">the id or type of thing to get (latest, now_playing, popular, top_rated, upcoming)</param>
        /// <returns></returns>
        public static dynamic GetItemFromApi(string category = "movie", string idOrType = "82703")
        {
            string ApiString = $"https://api.themoviedb.org/3/{category}/{idOrType}?api_key={key}&language=en-UK";
            var ApiResponse = client.GetStringAsync(ApiString).Result;
            return JsonConvert.DeserializeObject<dynamic>(ApiResponse);
        }

        /// <summary>
        /// gets <see cref="BitmapImage"/> from https://image.tmdb.org/t/p/<paramref name="dimensions"/>/<paramref name="extension"/>
        /// </summary>
        /// <param name="extension">the extension at the end of the link that is used to identify the image</param>
        /// <param name="dimensions">the dimensions for the image, (w600_and_h900)</param>
        /// <returns></returns>
        public static BitmapImage GetImage(string extension, string dimensions = "original")
        {
            return new BitmapImage(new Uri("https://image.tmdb.org/t/p/" + dimensions + extension));
        }
    }
}