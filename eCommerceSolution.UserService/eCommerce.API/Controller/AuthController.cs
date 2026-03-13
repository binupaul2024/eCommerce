using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
 

namespace eCommerce.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Core.DTO.RegisterRequest registerRequest)
        {

            //check for invalid registerRequest

            if(registerRequest == null || string.IsNullOrEmpty(registerRequest.Email) || string.IsNullOrEmpty(registerRequest.Password) || string.IsNullOrEmpty(registerRequest.PersonName))
            {
                return BadRequest("Invalid register request");
            }


            AuthenticationResponse? auth =  await _userService.Register(registerRequest);

            if (auth == null || auth.Sucess == false)
            {
                return BadRequest("Registration failed");
            }


            return Ok(auth);


        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(Core.DTO.LoginRequest loginRequest)
        {

            //check for invalid registerRequest

            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Invalid Login data");
            }

            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);

            if(authenticationResponse ==null || authenticationResponse.Sucess == false)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse); ;

        }



    }
}
