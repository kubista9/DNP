namespace Shared.DTOs;

public class HoleScoreCreationDto
{
	public int HoleId { get; set; }
	public int RoundId { get; set; }
	public int NumOfStrikes { get; set; }

	public HoleScoreCreationDto(int holeId, int roundId, int numOfStrikes)
	{
		HoleId = holeId;
		RoundId = roundId;
		NumOfStrikes = numOfStrikes;
	}
}
