using System.ComponentModel.DataAnnotations;
using JWT.Models;

namespace WebApi.Services;

public class AuthService : IAuthService
{

	private readonly IList<User> _users = new List<User>
	{
		new User
		{
			Age = 36,
			Email = "trmo@via.dk",
			Domain = "via",
			Name = "Troels Mortensen",
			Password = "onetwo3FOUR",
			Role = "Teacher",
			Username = "trmo",
			SecurityLevel = 4
		},
		new User
		{
			Age = 34,
			Email = "jakob@gmail.com",
			Domain = "gmail",
			Name = "Jakob Rasmussen",
			Password = "password",
			Role = "Student",
			Username = "jknr",
			SecurityLevel = 2
		}
	};

	public Task<User> ValidateUser(string? username, string password)
	{
		User? existingUser = _users.FirstOrDefault(u =>
			u.Username!.Equals(username, StringComparison.OrdinalIgnoreCase));

		if (existingUser == null)
		{
			throw new Exception("User not found");
		}

		if (!existingUser.Password!.Equals(password))
		{
			throw new Exception("Password mismatch");
		}

		return Task.FromResult(existingUser);
	}

	public Task RegisterUser(User user)
	{

		if (string.IsNullOrEmpty(user.Username))
		{
			throw new ValidationException("Username cannot be null");
		}

		if (string.IsNullOrEmpty(user.Password))
		{
			throw new ValidationException("Password cannot be null");
		}
		// Do more user info validation here

		// save to persistence instead of list

		_users.Add(user);

		return Task.CompletedTask;
	}
}
