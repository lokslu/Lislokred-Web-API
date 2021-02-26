using Lislokred_Web_API.Models.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Lislokred_Web_API.Models;

namespace Lislokred_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreRepository genreRepository;
        public GenreController(ApplicationContext context)
        {
            genreRepository = new GenreRepository(context);
        }
        [HttpGet]
        public IEnumerable<GenreModel> GetAllGanres()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreModel>());

            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreModel>>(genreRepository.Get());
             
        }
    }
}
