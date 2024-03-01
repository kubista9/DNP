namespace Shared.DTOs;

public class SearchHoleScoreParametersDto
{
	public int HoleId { get; set; }
	public int RoundId { get; set; }
	public int NumberOfStrikes { get; set; }

	public SearchHoleScoreParametersDto(int holeId, int roundId, int numberOfStrikes)
	{
		HoleId = holeId;
		RoundId = roundId;
		NumberOfStrikes = numberOfStrikes;
	}
}
