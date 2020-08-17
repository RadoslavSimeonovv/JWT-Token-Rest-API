using AppGreat.Services.Contracts;
using AppGreat.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppGreat.Services.Mappers;
using APIGreat.Data;
using AppGreat.Services.Models;
using AppGreat.Data.Entities;
using AppGreat.Services.Helpers;
using Microsoft.Extensions.Options;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AppGreat.Services
{
    public class UserService : IUserService
    {
        private readonly AppGreatContext _appGreatContext;
        private readonly AppSettings _appSettings;
        public UserService(AppGreatContext appGreatContext, IOptions<AppSettings> appSettings)
        {
            this._appGreatContext = appGreatContext;
            _appSettings = appSettings.Value;
        }

        /*
         * Authenticate the user, login and generate the JWT token from the helper method
        */

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user =  _appGreatContext.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        /*
       * Get all users method
        */
        public IEnumerable<User> GetAll()
        {
           return _appGreatContext.Users
               .ToList();
        }

        /*
         * Get user by id method used by the JWT middleware
        */

        public User GetById(int id)
        {
            return _appGreatContext.Users
                .FirstOrDefault(x => x.Id == id);
        }

        /*
         * Generate a JWT Toekn after a successful login by the user
        */
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /*
       * Register new user by name, password and currency code
       */
        public async Task<UserDTO> RegisterUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ArgumentNullException("User doesn't exist!");
            }

            var user = userDTO.MapUserDTOToModel();

            await _appGreatContext.Users.AddAsync(user);
            await _appGreatContext.SaveChangesAsync();

            return userDTO;
        }
    }
}
