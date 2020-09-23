using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace MovieAPI
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        const string server = "Server=7RP7Q13\\SQLEXPRESS;Database=Movie;user id=csharp;password=abc123"; //Dave Server

        public static Random rand = new Random();

        public static void Create(string title, string category)
        {
            IDbConnection db = new SqlConnection(server);
            Movie mov = new Movie()
            {
                Title = title,
                Category = category
            };
            db.Insert(mov);
        }

        public static List<Movie> ReadAll()
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> M = db.Query<Movie>($"select * from [Movie]").AsList<Movie>();
            return M;
        }

        public static List<Movie> CategorySearch(string cat)
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> M = db.Query<Movie>($"select * from [Movie] where Category = '{cat}'").AsList<Movie>();
            return M;
        }

        /*
        public static List<Movie> TitleSearch(string title)
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> M = db.Query<Movie>($"select * from [Movie] where Title = {title}").AsList<Movie>();
            return M;
        }
        */

        public static Movie RandomMovie()
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> M = db.Query<Movie>($"select * from [Movie]").AsList<Movie>();
            int result = rand.Next(0, M.Count);

            return M[result];
        }

        public static Movie CategoryRandomMovie(string cat)
        {
            List<Movie> M = new List<Movie>();
            M = Movie.CategorySearch(cat);
            int result = rand.Next(0, M.Count);

            return M[result];
        }

        public static List<Movie> TitleSearch(string title)
        {
            IDbConnection db = new SqlConnection(server);
            List<Movie> M = db.Query<Movie>($"select * from [Movie] where Title LIKE '%{title}%'").AsList<Movie>();
            return M;
        }


    }
}
