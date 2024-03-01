using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class HoleScore
{
	public int HoleScoreId { get; set; }
	[Range(1, 25, ErrorMessage = "Number of strikes must be between 1 and 25")]
	public int HoleId { get; set; }
	public int RoundId { get; set; }
	[Range(1, 10, ErrorMessage = "Number of strikes must be between 1 and 10")]
	public int NumOfStrikes { get; set; }

	public Player Player { get; private set; }
	public int PlayerId { get; set; }

	public HoleScore()
	{

	}
}
