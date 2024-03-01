using System.Text.Json;
using Domain.DTOs;
using Domain.models;

namespace HttpClient.ClientInterfaces;

public interface IUserService
{
	Task<User> Create(UserCreationDto dto);
}
