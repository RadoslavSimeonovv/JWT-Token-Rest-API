using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGreat.Services.Contracts;
using AppGreat.Services.Helpers;
using AppGreat.Services.Models;
using AppGreat_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppGreat_API.Mappers;

namespace AppGreat_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);


            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> RegisterUser([FromBody] UserViewModel userVM)
        {
            try
            {
                var userDTO = userVM.MapUserVMToDTO();
                var user = await _userService.RegisterUser(userDTO);

        
                return Created("Post", user);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
