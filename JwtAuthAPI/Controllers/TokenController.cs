using JwtAuthAPI.DataAccess;
using JwtAuthAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthAPI.Controllers
{
    /// <summary>
    /// Tokens
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    public class TokenController : ControllerBase
    {
        /// <summary>
        /// Gets list of Tokens.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TokenDto>> ListAsync()
        {
            return Ok(ListStore.Tokens.Select(x => new TokenDto(x)).ToList());
        }
    }
}