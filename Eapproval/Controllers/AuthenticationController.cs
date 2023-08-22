using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;
using Eapproval.Helpers;
using Eapproval.services;
using Eapproval.Models;
using System.Text.Json;

namespace Eapproval.Controllers
{
    [ApiController]
    [Route("/")]
    public class AuthenticationController : Controller
    {

        private readonly UserApi _userApi;
        private readonly UsersService _usersService;
        private readonly JwtTokenService _jwtTokenService;

        public AuthenticationController(UserApi userApi, UsersService usersService, JwtTokenService jwtTokenService)
        {
                _userApi = userApi;
             _usersService = usersService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(IFormCollection data)
        {
            var result = await _usersService.GetUserByMail(data["MailAddress"]);

                if(result != null)
            {
                dynamic newData = new
                {
                    registered = false,
                    message = "This email is already registered"
                };

                      return new JsonResult(newData);
            }
            else
            {
                var user = JsonSerializer.Deserialize<User>(data["user"]) ;
                user.UserType = "normal";
                user.Password = data["Password"];
              
                await _usersService.CreateAsync(user);
                return Ok(true);

            };

            
        }



        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginData data)
        {
            var email = data.Email;
            var password = data.Password;

            Console.WriteLine("this is the email");
            Console.WriteLine(email);

            var result =await  _usersService.GetUserByMailAndPassword(email, password);

            if(result != null)
            {
                var token = _jwtTokenService.GenerateToken(result);
                

                dynamic newData = new
                {
                    result = result,
                    token = token,
                    success = true,

                };

                return new JsonResult(newData);
            }
            else
            {
                dynamic newData = new { success = false, message = "This user is not authorized" };
                return new JsonResult(newData);
            }
        }




    }
}
