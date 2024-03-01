using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Models;

public class Player
{
	public int PlayerId { get; set; }
	[MaxLength(50, ErrorMessage = "Name has more than 50 characters.")]
	public string Name { get; set; }
	[Range(18, 99, ErrorMessage = "Invalid age.")]
	public int Age { get; set; }
	public string? Phone { get; set; }
	[Range(1000.00,5000.00, ErrorMessage = "Invalid membership fee.")]
	public double MembershipFee { get; set; }
	[RegularExpression("^(basic|full|premium)$", ErrorMessage = "Invalid membership type.")]
	public string MembershipType { get; set; }
	[JsonIgnore]
	public ICollection<HoleScore> Scores { get; set; }

	public Player()
	{

	}
}
