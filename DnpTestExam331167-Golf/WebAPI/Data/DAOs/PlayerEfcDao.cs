using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DTOs;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PlayerEfcDao : IPlayerDao
{
	private readonly GolfContext _context;

	public PlayerEfcDao(GolfContext context)
	{
		_context = context;
	}

	public async Task<Player> CreateAsync(Player player)
	{
		try
		{
			/*EntityEntry<Player> newPlayer =*/await _context.Players.AddAsync(player);
			await _context.SaveChangesAsync();
			return player;
		}
		catch (Exception e)
		{
			throw new Exception($"Error adding player: {e.Message}", e);
		}
	}

	public async Task<Player?> GetByNameAsync(string name)
	{
		Player? existing = await _context.Players.FirstOrDefaultAsync(
			p =>p.Name.ToLower().Equals(name.ToLower()));
		return existing;
	}

	public async Task<IEnumerable<Player>> GetAsync(SearchPlayerParametersDto searchParameters)
	{
		IQueryable<Player> usersQuery = _context.Players.AsQueryable();
		if (searchParameters.Name != null)
		{
			usersQuery = usersQuery.Where(p => p.Name.ToLower().Contains(searchParameters.Name.ToLower()));
		}

		IEnumerable<Player> result = await usersQuery.ToListAsync();
		return result;
	}

	public async Task<Player?> GetByIdAsync(int id)
	{
		Player? player = await _context.Players.FindAsync(id);
		return player;
	}
}
