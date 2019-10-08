using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT.Senad.Youtube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost("token")]
        public IActionResult GetToken([FromBody] RequestModel model)
        {

            // Creating security key 1) String 2) to byte[] 3) to SymmetricSecurityKey
            string securityKey = "private static void GetSuperLongSecurityKey()";
            byte[] securityKeyInBytes = Encoding.ASCII.GetBytes(securityKey);
            var symmetricSecurityKey = new SymmetricSecurityKey(securityKeyInBytes);


            // sign in credentials 
            var signInCredentials = new SigningCredentials(key: symmetricSecurityKey,
                                                           algorithm: SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.Role, model.Role)
            };

            // create token
            var jwtToken = new JwtSecurityToken(issuer: "me.for.example",
                                                 audience: "them.from.example",
                                                 claims: claims,
                                                 expires: DateTime.UtcNow.AddSeconds(1),
                                                 signingCredentials: signInCredentials);

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var responseResult = new
            {
                token = token,
                utcNow = DateTime.UtcNow.AddMinutes(1).ToString(),
                now= DateTime.Now.AddMinutes(1).ToString()
            };

            return Ok(responseResult);
        }
       
    }
}
