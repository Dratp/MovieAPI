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
    }
}
