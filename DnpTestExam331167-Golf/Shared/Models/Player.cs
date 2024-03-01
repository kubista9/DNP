namespace Shared.Models;

public class Player
{
	public int PlayerId { get; set; }
	public string? Name { get; set; }
	public int Age { get; set; }
	public string? Phone { get; set; }
	public double MembershipFee { get; set; }
	public string? MembershipType { get; set; }
	public ICollection<HoleScore>? HoleScores { get; set; }

	public Player(string name, int age, string? phone, double membershipFee, string membershipType)
	{
		Name = name;
		Age = age;
		Phone = phone;
		MembershipFee = membershipFee;
		MembershipType = membershipType;
	}

	public Player()
	{

	}
}
