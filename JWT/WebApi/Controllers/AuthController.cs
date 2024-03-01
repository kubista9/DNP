using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWT.Dtos;
using JWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Services;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
	private readonly IConfiguration _config;
	private readonly IAuthService _authService;

	public AuthController(IConfiguration config, IAuthService authService)
	{
		_config = config;
		_authService = authService;
	}

	private List<Claim> GenerateClaims(User user)
	{
		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]!),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
			new Claim(ClaimTypes.Name, user.Username!),
			new Claim(ClaimTypes.Role, user.Role!),
			new Claim("DisplayName", user.Name!),
			new Claim("Email", user.Email!),
			new Claim("Age", user.Age.ToString()),
			new Claim("Domain", user.Domain!),
			new Claim("SecurityLevel", user.SecurityLevel.ToString())
		};
		return claims.ToList();
	}

	private string GenerateJwt(User user)
	{
		List<Claim> claims = GenerateClaims(user);

		SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
		SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

		JwtHeader header = new JwtHeader(signIn);

		JwtPayload payload = new JwtPayload(
			_config["Jwt:Issuer"],
			_config["Jwt:Audience"],
			claims,
			null,
			DateTime.UtcNow.AddMinutes(60));

		JwtSecurityToken token = new JwtSecurityToken(header, payload);

		string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
		return serializedToken;
	}

	[HttpPost, Route("login")]
	public async Task<ActionResult> Login([FromBody] UserLoginDto userLoginDto)
	{
		try
		{
			User user = await _authService.ValidateUser(userLoginDto.Username, userLoginDto.Password!);
			string token = GenerateJwt(user);

			return Ok(token);
		}
		catch (Exception e)
		{
			return BadRequest(e.Message);
		}
	}
}
