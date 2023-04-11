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
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            this._registerService = registerService;
        }

        /// <summary>
        /// Register new user.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> RegisterAsync(RegisterUserRequestDto dto)
        {
            var response = await _registerService.RegisterUser(dto);

            return Ok(response);
        }
    }
}