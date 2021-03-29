using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lislokred_Web_API.Models.Entitys;
using Microsoft.Extensions.Options;
using Lislokred_Web_API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace Lislokred_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class MoviesController : ControllerBase
    {
        private readonly MovieRepository movieRepository;


        public MoviesController(ApplicationContext context)
        {
            movieRepository = new MovieRepository(context);

        }

        [HttpPost("AddMovie")]
        [Authorize(Roles = "admin")]
        public IActionResult AddMovie([FromBody] MovieCreateModel movie)
        {
            movieRepository.Create(movie);
            //вызов медиа менеджера и загрузка картинки в файловую систему;
            return Ok();
        }
        [HttpDelete("RemoveMovie")]
        [Authorize(Roles = "admin")]
        public IActionResult RemoveMovie([FromBody] Guid MovieId)
        {
            if (movieRepository.Remove(MovieId))
            {
                return Ok();
            }
            else
            {
                
                return NotFound();
            }
        }

        [HttpGet("FullInformation/{MovieId}")]
        [AllowAnonymous]

        public IActionResult GetMovieFullInformatin(string MovieId)
        {
            var Userid = User.Claims.FirstOrDefault(c => c.Type == "Id");
            MovieFullInformationModel movie;

            movie = movieRepository.GetMovieFullinfModelById(Guid.Parse(MovieId), Userid?.Value);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [HttpGet("Serch/{MovieName}")]
        public IActionResult SerchByName(string MovieName)
        {
            var Userid = User.Claims.FirstOrDefault(c => c.Type == "Id");
            

            var movies = movieRepository.Serch(MovieName, Userid?.Value);
     
             return Ok(movies);
           

        }

        [HttpGet("{MovieId}")]

        public IActionResult Get(string MovieId)
        {
            var Userid = User.Claims.FirstOrDefault(c => c.Type == "Id");
            MovieModel movie;

            movie = movieRepository.GetMovieModelById(Guid.Parse(MovieId), Userid?.Value);
            if (movie==null)
            {
                return NotFound();
            }
            else
            {
            return Ok(movie);
            }
        }

        [HttpGet("ToBeSeenMovie")]
        public IActionResult GetToBeSeenMovie()
        {
            var Userid = User.Claims.FirstOrDefault(c => c.Type == "Id");
            var result = this.movieRepository.GetToBeSeenMovie(Guid.Parse(Userid.Value));
            return Ok(result);
        }

        [HttpGet("SeenMovie")]
        public IActionResult GetSeenMovie()
        {
            var Userid = User.Claims.FirstOrDefault(c => c.Type == "Id");
            var result=this.movieRepository.GetSeenMovie(Guid.Parse(Userid.Value));
            return Ok(result);
        }

        [HttpGet("All")]
        public IActionResult GetAllMovie()
        {
            var Userid = User.Claims.FirstOrDefault(c => c.Type == "Id");
            
            var movie = movieRepository.GetAllMovie(Userid?.Value);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [HttpGet("API search/{MovieName}")]
        public  IActionResult Serch(string MovieName)
        { 
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb8.p.rapidapi.com/title/find?q=" + MovieName),
                Headers =
                {
                    { "x-rapidapi-key", "18ac0e848bmshdcdd1986cfada8bp1b31a9jsn42348ff61ca1" },
                    { "x-rapidapi-host", "imdb8.p.rapidapi.com" },
                },
            };
            using (var response =  client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                var body =  response.Content.ReadAsStringAsync();
                return Ok(body.Result);
            }
        }
    }
}
