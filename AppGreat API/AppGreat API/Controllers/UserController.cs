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

        /*
       * Login user
       * by using the appropriate service method
       * http://localhost:5000/api/users/login - request URL
       */
        [HttpPost("login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);


            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        /*
         * Retrieve all users
         * by using the appropriate service method
         * http://localhost:5000/api/users/ - request URL
         */
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        /*
        * Register a new user
        * by using the appropriate service method
        * http://localhost:5000/api/users/register - request URL
        */
        [HttpPost("register")]
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
