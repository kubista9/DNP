using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DTOs;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class HoleScoreEfcDao : IHoleScoreDao
{
	private readonly GolfContext _context;

	public HoleScoreEfcDao(GolfContext context)
	{
		_context = context;
	}

	public async Task<HoleScore> CreateAsync(HoleScore holeScore)
	{
		EntityEntry<HoleScore> added = await _context.HoleScores.AddAsync(holeScore);
		await _context.SaveChangesAsync();
		return added.Entity;
	}

	public async Task<IEnumerable<HoleScore>> GetAsync(SearchHoleScoreParametersDto searchParameters)
	{
		IQueryable<HoleScore> query = _context.HoleScores.Include(holeScore => holeScore.HoleId).AsQueryable();

		if (searchParameters.HoleId != null)
		{
			query = query.Where(holeScore => holeScore.HoleId == searchParameters.HoleId);
		}
		if (searchParameters.RoundId != null)
		{
			query = query.Where(holeScore => holeScore.RoundId == searchParameters.RoundId);
		}
		if (searchParameters.NumberOfStrikes != null)
		{
			query = query.Where(holeScore => holeScore.NumberOfStrikes == searchParameters.NumberOfStrikes);
		}

		List<HoleScore> result = await query.ToListAsync();
		return result;
	}

	public async Task<HoleScore?> GetByIdAsync(int holeId)
	{
		HoleScore? found = await _context.HoleScores
			.AsNoTracking()
			.Include(holeScore => holeScore.HoleId)
			.SingleOrDefaultAsync(holeScore => holeScore.HoleId == holeId);
		return found;
	}
}
