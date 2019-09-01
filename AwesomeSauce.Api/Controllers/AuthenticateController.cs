using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AwesomeSauce.Api.Controllers
{
    [Route("api/authenticate")]
    public class AuthenticateController : Controller
    {
        private readonly IConfiguration configuration;

        public AuthenticateController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Post()
        {
            var authorizationHeader = Request.Headers["Authorization"].First();
            var key = authorizationHeader.Split(' ')[1];
            var credentials = Encoding.UTF8.GetString(Convert.
            FromBase64String(key)).Split(':');
            var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
            (configuration["JWT:ServerSecret"]));
            if (credentials[0] == "awesome-username" && credentials[1] ==
            "awesome-password")
            {
                var result = new
                {
                    token = GenerateToken(serverSecret)
                };
                return Ok(result);
            }
            return BadRequest();
        }

        private string GenerateToken(SecurityKey key)
        {
            var now = DateTime.UtcNow;
            var issuer = configuration["JWT:Issuer"];
            var audience = configuration["JWT:Audience"];
            var identity = new ClaimsIdentity();
            var signingCredentials = new SigningCredentials(key,
            SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(issuer, audience, identity,
            now, now.Add(TimeSpan.FromHours(1)), now, signingCredentials);
            var encodedJwt = handler.WriteToken(token);
            return encodedJwt;
        }
    }
}