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
        private readonly FilmingUnitRepository filmingUnitRepository;
        public FilmingUnitController(ApplicationContext context)
        {
            filmingUnitRepository = new FilmingUnitRepository(context);
        }
        [HttpGet("{MovieId}")]
        public IActionResult GetUnitsByMovieId(string MovieId)
        {
            var units = filmingUnitRepository.GetByMovieId(Guid.Parse(MovieId));
                return Ok(units);
        }
    }
}
