using Lislokred_Web_API.Models;
using Lislokred_Web_API.Models.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lislokred_Web_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;
        private readonly IOptions<AuthOption> authOption;

        public UserController(ApplicationContext context, IOptions<AuthOption> authOptions)
        {
            userRepository = new UserRepository(context);
            this.authOption = authOptions;

        }
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterModel model)
        {

            //переобразование из модели(RegisterModel) в сущьность(User)

            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
                Nickname = model.Nickname,
            };
            if (model.Gender.HasValue)
                user.Gender = model.Gender.Value ? "M" : "W";
            foreach (var i in model.FavoriteGenres)
            {
                user.UserToGenre.Add(new UserToGenre { UserId = user.Id, GanreId = i.Id });
            }



            if (userRepository.OriginalityCheckNicknameAndEmail(user.Nickname, user.Email))
            {
                userRepository.Create(user);
                // Ok();
                return this.Login(new LoginModel() { Email = user.Email, Password = user.Password });
            }
            else
            {
                //Response.StatusCode = 400;
                //Response.WriteAsync("User with this Nickname already exists.");

                return BadRequest("User with this Nickname already exists.");
            }
        }
        //[SwaggerResponse((int)HttpStatusCode.OK, "", typeof())]
        [HttpPost("cheknickname")]
        [AllowAnonymous]
        public IActionResult CheckNewNickname([FromBody] String newNick)
        {
            bool state = userRepository.OriginalityCheckNickname(newNick);
            return Ok(new { original = state });
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel model)
        {

            var identity = GetIdentity(model.Email, model.Password);

            if (identity == null)
            {
                return Unauthorized();
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var authOptions = this.authOption.Value;

            var jwt = new JwtSecurityToken(
                    issuer: authOptions.Issuer,
                    audience: authOptions.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(authOptions.TokenLifetime)),
                    signingCredentials: new SigningCredentials(authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);


            // сериализация ответа
            Response.ContentType = "application/json";
            Console.WriteLine("Login succeed");
            return Ok(new { token = encodedJwt });
        }

        private ClaimsIdentity GetIdentity(string email, string password)// тип ClaimsIdentity
        {
            var user = userRepository.AuthenticateUser(email, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim("Id",user.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType,"user"),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

    }
}
