using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetUserById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDto userDto)
        {
            _userService.AddUser(userDto);
            return Ok("Kullanıcı eklendi.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserDto userDto)
        {
            _userService.UpdateUser(userDto);
            return Ok("Kullanıcı güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok("Kullanıcı silindi.");
        }
    }
}
