using JwtAuthAPI.Dtos;
using JwtAuthAPI.Services.Interfacces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _tokenService;

        public AuthController(IAuthService tokenService)
        {
            this._tokenService = tokenService;
        }

        /// <summary>
        /// Log in with username/password
        /// </summary>
        /// <param name="dto">Login Data</param>
        /// <returns></returns>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponseDto>> LoginAsync(LoginRequestDto dto)
        {
            var response = await _tokenService.Login(dto);

            return Ok(response);
        }

        /// <summary>
        /// Logout with token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost("Logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> LogoutAsync([FromHeader(Name = "Authentication")] string token)
        {
            await _tokenService.Logout(token);

            return Ok();
        }
    }
}