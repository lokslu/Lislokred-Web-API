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
        [Authorize]
        [HttpPost("AddReletion")]
        public IActionResult AddMovieTouser([FromBody] StateAndRateModel reletion)
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

        [Authorize]
        [HttpDelete("RemoveReletion")]
        public IActionResult Remove([FromBody] Guid MovieId)
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

        [Authorize]
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
    }
}
