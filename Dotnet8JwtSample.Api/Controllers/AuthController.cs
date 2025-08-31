using Microsoft.AspNetCore.Mvc;
using Dotnet8JwtSample.Application.Services;
using Dotnet8JwtSample.Infrastructure.Repositories;
using Dotnet8JwtSample.Domain.Entities;

namespace Dotnet8JwtSample.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(IUserRepository userRepository, JwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userRepository.GetByUsername(request.Username);
            if (user == null || user.Password != request.Password)
            {
                return Unauthorized();
            }
            var token = _jwtTokenService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}