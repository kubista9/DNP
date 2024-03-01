namespace Shared.Models;

public class HoleScore
{
	public int HoleId { get; set; }
	public int RoundId { get; set; }
	public int NumberOfStrikes { get; set; }

	public HoleScore(int holeId, int roundId, int numberOfStrikes)
	{
		HoleId = holeId;
		RoundId = roundId;
		NumberOfStrikes = numberOfStrikes;
	}
}
