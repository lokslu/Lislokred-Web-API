using Lislokred_Web_API.Models.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lislokred_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class FilmingUnitController : ControllerBase
    {
        private readonly Environment config;
        private readonly FilmingUnitRepository filmingUnitRepository;
        public FilmingUnitController(ApplicationContext context, Environment config)
        {
            filmingUnitRepository = new FilmingUnitRepository(context);
            this.config = config;
        }
        [HttpGet("{MovieId}")]
        public IActionResult GetUnitsByMovieId(string MovieId)
        {
            var units = filmingUnitRepository.GetByMovieId(Guid.Parse(MovieId),config.ApplicationUrl).ToList();
                return Ok(units);
        }
    }
}
