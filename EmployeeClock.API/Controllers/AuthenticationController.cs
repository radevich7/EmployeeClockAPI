using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeClock.API.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        //not using it outside of the class

        public class AuthenticationrequestBody
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }


        public class UserInfo
        {

            public int UserID { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public UserInfo(int userID, string userName, string firstName, string lastName)
            {
                UserID = userID;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
            }

        }


        [HttpPost("authenticate")]

        public ActionResult<string> Authenticate(AuthenticationrequestBody authenticationrequestBody)
        {
            var user = ValidateUserCredentials(
                authenticationrequestBody.Username,
                authenticationrequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            //Create a token

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Claims

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserID.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));


            //JWT

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);

        }

        private UserInfo ValidateUserCredentials(string? userName, string? password)
        {
            //process of checking password and user name

            return new UserInfo(
                1,
                userName ?? "",
                "Julian",
                "Radevych");
        }

    }
}
