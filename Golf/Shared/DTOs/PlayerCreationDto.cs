namespace Shared.DTOs;

public class PlayerCreationDto
{
	public string Name { get; set; }
	public int Age { get; set; }
	public string? Phone { get; set; }
	public double MembershipFee { get; set; }
	public string MembershipType { get; set; }

	public PlayerCreationDto(string name, int age, string? phone, double membershipFee, string membershipType)
	{
		Name = name;
		Age = age;
		Phone = phone;
		MembershipFee = membershipFee;
		MembershipType = membershipType;
	}
}
