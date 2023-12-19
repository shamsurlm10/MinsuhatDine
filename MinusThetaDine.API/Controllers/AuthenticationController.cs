using Microsoft.AspNetCore.Mvc;
using MinusTheta.Application.Services.Authentication;
using MinusTheta.Contracts.Authentication;

namespace MinusThetaDine.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = _service.Login(
                request.Email,
                request.Password
            );
            var response = new AuthenticationResponse
            (
                result.User.Id,
                result.User.FirstName,
                result.User.LastName,
                result.User.Email,
                result.Token
            );
            return Ok(response);
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            var result = _service.Register
            (
                request.FirstName, 
                request.LastName, 
                request.Email, 
                request.Password
            );

            var response = new AuthenticationResponse
            (
                result.User.Id,
                result.User.FirstName,
                result.User.LastName,
                result.User.Email,
                result.Token
            );
            return Ok(response);
        }
    }
}
