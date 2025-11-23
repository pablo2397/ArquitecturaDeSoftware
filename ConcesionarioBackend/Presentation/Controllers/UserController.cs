using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IServiceUser _userService;
        public UserController(IServiceUser userService)
        {
            _userService = userService;
        }

        [HttpPost("USerCreate")]
        public async Task<IActionResult> UserCreateAsync([FromBody]UserDto userDto)
        {
            User user = new User()
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Role = "User"  // Asignado internamente
            };

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var create = await _userService.CreateUserAsync(user);
            return Ok(new { message = "Se creo exitosamente" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var login = await _userService.LoginAsync(userDto);
            return Ok(new { message = "Bienvenido" });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _userService.UpdateAsync(user);

            if (exists == null)
                return NotFound(new { message = "No se encontró el registro para actualizar" });

            return Ok(new { message = "Se actualizo exitosamente" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var users = await _userService.GetAllUserAsync();
            return  Ok(users);
        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var exists = await _userService.GetId(id);

            if (exists == null)
                return NotFound(new { message = "No se encontró el registro para eliminar" });

            await _userService.DeleteAsync(id);
            return Ok(new { message = "Se elimino exitosamente" });
        }
    }
}
