using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Data;

public class SqliteDataAccess : IDataAccess
{
	private readonly GolfDbContext _context;

	public SqliteDataAccess(GolfDbContext context)
	{
		_context = context;
	}

	public async Task<Player> CreatePlayerAsync(PlayerCreationDto dto)
	{
		ValidatePlayer(dto);
		Player playerToCreate = new Player
		{
			Name = dto.Name,
			Age = dto.Age,
			Phone = dto.Phone,
			MembershipFee = dto.MembershipFee,
			MembershipType = dto.MembershipType
		};

		EntityEntry<Player> newPlayer = await _context.Players.AddAsync(playerToCreate);
		await _context.SaveChangesAsync();
		return newPlayer.Entity;
	}

	public async Task<HoleScore> CreateHoleScoreAsync(HoleScoreCreationDto dto)
	{
		ValidateHoleScore(dto);
		HoleScore holeScoreToCreate = new HoleScore()
		{
			HoleId = dto.HoleId,
			RoundId = dto.RoundId,
			NumOfStrikes = dto.NumOfStrikes,

		};

		EntityEntry<HoleScore> newHoleScore = await _context.HoleScores.AddAsync(holeScoreToCreate);
		await _context.SaveChangesAsync();
		return newHoleScore.Entity;
	}

	public async Task<double> GetAverageStrikesAsync(int holeId)
	{
		int strikes = 0;
		int players = _context.Players.Count();
		IQueryable<HoleScore> holeScores = _context.HoleScores;

		foreach (var holeScore in holeScores)
		{
			if (holeScore.HoleId == holeId)
			{
				strikes += holeScore.NumOfStrikes;
			}
		}

		double averageStrikes = strikes / players;
		return averageStrikes;
	}

	public async Task<int> GetPlayerIdHandicap(int playerId)
	{
		var player = await _context.Players.Include(p => p.Scores).FirstOrDefaultAsync(p => p.PlayerId == playerId);
		if (player == null)
		{
			throw new Exception("Player not found.");
		}

		var handicap = player.Scores.Sum(hs => hs.NumOfStrikes);
		return handicap;
	}

	public async Task<int> GetRoundIdStrikesByPlayer(int roundId, int playerId)
	{
		var scores = await _context.HoleScores
			.Where(hs => hs.PlayerId == playerId && hs.RoundId == roundId)
			.ToListAsync();

		// Sum up the number of strikes
		int totalStrikes = scores.Sum(hs => hs.NumOfStrikes);

		return totalStrikes;
	}

	public async Task<Player?> GetByIdAsync(int playerId)
	{
		Player? player = await _context.Players.FindAsync(playerId);
		return player;
	}

	private static void ValidatePlayer(PlayerCreationDto dto)
	{
		string type1 = "basic";
		string type2 = "full";
		string type3 = "premium";

		string membershipType = dto.MembershipType;

		if (!membershipType.Equals("basic") && !membershipType.Equals("full") && !membershipType.Equals("premium"))
		{
			throw new Exception("Membership type must be either: basic, full, or premium");
		}
	}

	private static void ValidateHoleScore(HoleScoreCreationDto dto)
	{
		if (dto.HoleId < 1 || dto.HoleId > 25)
		{
			throw new Exception("Hole ID must be between 1 and 25");
		}

		if (dto.NumOfStrikes < 1 || dto.NumOfStrikes > 10)
		{
			throw new Exception("Number of strikes must be between 1 and 10");
		}

	}
}
