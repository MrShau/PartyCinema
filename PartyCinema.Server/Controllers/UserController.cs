using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PartyCinema.Server.Attributes;
using PartyCinema.Server.Dtos.User;
using PartyCinema.Server.Repositories.Interfaces;
using PartyCinema.Server.Services;

namespace PartyCinema.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors()]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRep;
        private readonly IRoleRepository _roleRep;

        private readonly JwtService _jwt;

        public UserController(IUserRepository userRep, JwtService jwtService, IRoleRepository roleRepository)
        {
            _userRep = userRep;
            _jwt = jwtService;
            _roleRep = roleRepository;
        }

        private string GetRequestLogin()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = _jwt.Verify(token);

            if (user?.Claims?.FirstOrDefault(c => c.Type == "login") == null)
                return "";

            return user.Claims.First(c => c.Type == "login").Value;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(RegUserDto dto)
        {
            try
            {
                if (_userRep.IsExist(dto.Login))
                    return Unauthorized(new
                    {
                        message = "Логин занят !"
                    });

                var role = await _roleRep.Get("DEFAULT");

                if (role == null)
                    return StatusCode(500, new
                    {
                        message = "Ошибка сервера (role)"
                    });

                var user = await _userRep.Add(new Models.User(dto.Login, dto.Password, role));

                if (user == null)
                    return StatusCode(500, new
                    {
                        message = "Ошибка сервера (user)"
                    });

                string token = _jwt.Generate(user.Login, user.Id);

                return Ok(new
                {
                    token
                });
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(RegUserDto dto)
        {
            try
            {
                if (!_userRep.IsExist(dto.Login))
                    return Unauthorized(new
                    {
                        message = "Логин не зарегистрирован !"
                    });

                var role = await _roleRep.Get("DEFAULT");
                if (role == null)
                    return StatusCode(500, new
                    {
                        message = "Ошибка сервера (role)"
                    });

                var user = await _userRep.Get(dto.Login);

                if (user == null)
                    return StatusCode(500, new
                    {
                        message = "Ошибка сервера (user)"
                    });

                if (!user.CheckPassword(dto.Password))
                    return Unauthorized(new
                    {
                        message = "Неправильный пароль !"
                    });

                string token = _jwt.Generate(user.Login, user.Id);

                return Ok(new
                {
                    token
                });
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("auth")]
        [JwtAuth]
        public async Task<IActionResult> Auth()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var user = _jwt.Verify(token);
                if (user == null)
                    return Unauthorized(new { error = "Токен недействителен !" });

                if (user.Claims?.FirstOrDefault(c => c.Type == "login") == null)
                    return Unauthorized(new { error = "Токен недействителен !" });

                var resultUser = await _userRep.Get(user.Claims.First(c => c.Type == "login").Value);

                if (resultUser == null)
                    return Unauthorized(new { error = "Токен недействителен !" });

                return Ok(new
                {
                    login = resultUser.Login,
                    userId = resultUser.Id,
                    imagePath = resultUser.ImagePath
                });
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return StatusCode(500, new
                {
                    error = "Ошибка сервера"
                });
            }
        }
    }
}
