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

namespace Lislokred_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieRepository movieRepository;
        //private readonly IOptions<AuthOption> AuthOption;

        public MoviesController(ApplicationContext context/*, IOptions<AuthOption> authOptions*/)
        {
            movieRepository = new MovieRepository(context);

            //this.AuthOption = authOptions;
        }

        [HttpPost("AddMovie")]
        [Authorize(Roles ="admin")]
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
       
        [HttpGet("{MovieId}")]

        public IActionResult Get(Guid MovieId)
        {
            var Userid = User.Claims.FirstOrDefault(c => c.Type == "Id");
            if (Userid!=null)
            { 
                var movie = movieRepository.GetMovieModelById(MovieId, Guid.Parse(Userid.Value));
            }
            return Unauthorized();
        }
        
    }
}
