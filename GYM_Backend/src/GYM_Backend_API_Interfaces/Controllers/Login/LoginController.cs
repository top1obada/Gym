using Gym_Backend_BusinessTier.Services.Login;
using Gym_Backend_BusinessTier.Services.Login.Session;
using Gym_Backend_DTO.Login;
using Gym_Backend_DTO.Login.Session;
using GYM_DTO.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectsServices.JWTServices;
using ProjectsServices.RefreshTokenServices;
using System.Security.Claims;

namespace GYM_Backend_API_Interfaces.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly scLoginService _scLoginService;
        private readonly IConfiguration _configuration;
        private readonly scSessionService _scSessionService;
        private readonly scLoginByRefreshTokenService _scLoginByRefreshTokenService;

        public LoginController(IConfiguration configuration, scLoginService scLoginService, scSessionService scSession,
            scLoginByRefreshTokenService scLoginByRefreshTokenService)
        {
            _scLoginService = scLoginService;
            _configuration = configuration;
            _scSessionService = scSession;
            _scLoginByRefreshTokenService = scLoginByRefreshTokenService;
        }

        [HttpPost("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<clsTokensDTO>> Login([FromBody] clsLoginRequirementsDTO SystemUserLoginRequirementsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(SystemUserLoginRequirementsDTO.Email) &&
                string.IsNullOrWhiteSpace(SystemUserLoginRequirementsDTO.PhoneNumber))
            {
                return BadRequest("Either Email or Phone Number must be provided.");
            }

            var userResult = await _scLoginService.Find(SystemUserLoginRequirementsDTO);

            if (userResult == null)
            {
                return Unauthorized("Invalid email/phone number or password.");
            }

            string rawRefreshToken = clsRefreshTokenHelper.GenerateRefreshToken();
            string hashedRefreshToken = clsRefreshTokenHelper.HashToken(rawRefreshToken);

            var sessionDto = new clsSystemUserSessionDTO
            {
                SystemUserID = userResult.PersonID,
                HashedRefreshToken = hashedRefreshToken,
                DeviceName = Request.Headers["User-Agent"].ToString()
            };

            var sessionId = await _scSessionService.Save(sessionDto);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userResult.PersonID.ToString()),
                new Claim(ClaimTypes.Name, userResult.FirstName),
                new Claim(ClaimTypes.Role, userResult.Role.ToString()),
                new Claim(ClaimTypes.Gender, userResult.Gender.ToString()),
                new Claim("JoiningDate", userResult.JoiningDate.Value.ToString()),
                new Claim("SessionID", sessionId.ToString())
            };

            var jwtTemplate = clsJWTHelper.GetToken(_configuration);
            string jwtToken = clsJWTHelper.GenerateJwtToken(claims, jwtTemplate);

            var tokens = new clsTokensDTO
            {
                JWTToken = jwtToken,
                RefreshToken = rawRefreshToken
            };

            return Ok(tokens);
        }

        [HttpPost("RefreshTokenLogin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<string>> RefreshTokenLogin([FromBody] string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return BadRequest("Refresh token must be provided.");
            }

            string hashedRefreshToken = clsRefreshTokenHelper.HashToken(refreshToken);
            var userResult = await _scLoginByRefreshTokenService.Find(hashedRefreshToken);

            if (userResult == null)
            {
                return Unauthorized("Invalid or expired refresh token.");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userResult.PersonID.ToString()),
                new Claim(ClaimTypes.Name, userResult.FirstName),
                new Claim(ClaimTypes.Role, userResult.Role.ToString()),
                new Claim(ClaimTypes.Gender, userResult.Gender.ToString()),
                new Claim("JoiningDate", userResult.JoiningDate.Value.ToString())
            };

            var jwtTemplate = clsJWTHelper.GetToken(_configuration);
            string jwtToken = clsJWTHelper.GenerateJwtToken(claims, jwtTemplate);

            return Ok(jwtToken);
        }
    }
}
