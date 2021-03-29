using Lislokred_Web_API.Models;
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
    [Authorize]
    public class StateAndRateController : ControllerBase
    {
        private readonly StateAndRateRepository stateAndRateRepository;
        public StateAndRateController(ApplicationContext context)
        {
            stateAndRateRepository = new StateAndRateRepository(context);
        }
        /*создание связи +
          удаление связи +
          изменение связи *
          подтягивание отзывов к фильму
         */
        [HttpPost("AddReletion")]
        public IActionResult AddMovieToUser([FromBody] StateAndRateModel reletion)
        {
            var UserId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var newRelation = new StateAndRate()
            {
                MovieId = reletion.MovieId,
                UserId = UserId,
                State = reletion.State,
                Rate = reletion?.Rate
            };

            stateAndRateRepository.Create(newRelation);
            return Ok();
        }

        [HttpDelete("RemoveReletion")]
        public IActionResult Remove([FromQuery] Guid MovieId)
        {
            var UserId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            if (stateAndRateRepository.Remove(MovieId, UserId))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateReletion")]
        public IActionResult Update([FromBody] StateAndRateModel reletion)
        {
            var UserId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var UpdateRelation = new StateAndRate()
            {
                UserId = UserId,
                MovieId = reletion.MovieId,
                State = reletion.State,
                Rate = reletion.Rate
            };
            stateAndRateRepository.Update(UpdateRelation);
            return Ok();
        }

        [HttpPut("ChangeRate")]
        public IActionResult ChangeRate([FromBody] StateAndRateModel reletion)
        {
            var UserId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var UpdateRelation = new StateAndRate()
            {
                UserId = UserId,
                MovieId = reletion.MovieId,
                State = reletion.State,
                Rate = reletion.Rate
            };
            if (stateAndRateRepository.ChangeRate(UpdateRelation))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("reviews/{MovieName}")]
        public IActionResult GetReviews(string MovieName)
        {
            var UserId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var Reviews= stateAndRateRepository.GetReviews(Guid.Parse(MovieName));

            return Ok(Reviews);
            
        }
    }
}
