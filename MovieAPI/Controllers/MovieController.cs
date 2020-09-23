using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    [Route("Movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        public IActionResult Info()
        {
            string a = "Get a list of all movies : Movies/All";
            string b = "Get a list of all movies in a specific category : Movies/Category/Parameter";
            string c = "Get a random movie pick : Movies/Random";
            string d = "Get a random movie pick from a specific category : Movies/{Category Parameter}/RandomMovie";
            string e = "Get a list of movies which have a keyword in their title : Movies/{Title Parameter}";
            string f = "There is a sql file to build the database";
            Response.ContentType = "text/html";
            return Content($"{a}<br />{b}<br />{c}<br />{d}<br />{e}<br />{f}");
        }

        //1. Get a list of all movies : Movies/All
        [HttpGet("All")]
        public List<Movie> All()
        {
            List<Movie> movies = new List<Movie>();
            movies = Movie.ReadAll();
            return movies;
        }

        // 2. Get a list of all movies in a specific category
        // User specifies category as a query parameter  : Movies/Category/Parameter
        [HttpGet("Category/{catid}")]
        public List<Movie> CategorySearch(string catid)
        {
            List<Movie> movies = new List<Movie>();
            movies = Movie.CategorySearch(catid);
            return movies;
        }

        // 3. Get a random movie pick : Movies/Random
        [HttpGet("Random")]
        public Movie RandomMovie()
        {
            Movie movie = new Movie();
            movie = Movie.RandomMovie();
            return movie;
        }

        // 4. Get a random movie pick from a specific category
        // User specifies category as a query parameter : Movies/Category/{Category varible}/RandomMovie
        [HttpGet("{cat}/Random")]
        public Movie CategoryRandomMovie(string cat)
        {
            Movie movie = new Movie();
            movie = Movie.CategoryRandomMovie(cat);
            return movie;
        }

        // 8. Get a list of movies which have a keyword in their title
        // User specifies title as a query parameter : Movies/{Title Parameter}
        [HttpGet("{title}")]
        public List<Movie> TitleSeach(string title)
        {
            List<Movie> M = new List<Movie>();
            M = Movie.TitleSearch(title);
            return M;
        }

    }
}
