using JwtAuthAPI.DataAccess;
using JwtAuthAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthAPI.Controllers
{
    /// <summary>
    /// Users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Gets lists of users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UserDto>> ListAsync()
        {
            return Ok(ListStore.Users.Select(x => new UserDto(x)).ToList());
        }
    }
}