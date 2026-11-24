using backend_api.Models;
using backend_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(string? firebaseUId = null)
        {
            string? idToUse = firebaseUId is null ? User.FindFirst("user_id").Value : firebaseUId;

            User userToReturn = new();

            try
            {
                userToReturn = await _userService.GetUserByFirebaseUid(idToUse);
                return Ok(userToReturn);
            } catch (KeyNotFoundException)
            {
                return NoContent();
            } catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
