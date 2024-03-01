namespace Shared.DTOs;

public class HoleScoreBasicDto
{
	public int HoleId { get; set; }
	public int RoundId { get; set; }
	public int NumberOfStrikes { get; set; }

	public HoleScoreBasicDto(int holeId, int roundId, int numberOfStrikes)
	{
		HoleId = holeId;
		RoundId = roundId;
		NumberOfStrikes = numberOfStrikes;
	}
}
