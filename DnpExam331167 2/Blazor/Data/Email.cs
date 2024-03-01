using System.ComponentModel.DataAnnotations;

namespace Blazor.Data;

public class Email
{
	public string Sender { get; set; }
	public string Receiver { get; set; }
	public string Title { get; set; }
	public string Body { get; set; }
	public DateTime Date { get; set; }

	public Email(string receiver, string title, string body, DateTime date, string sender)
	{
		Receiver = receiver;
		Title = title;
		Body = body;
		Date = date;
		Sender = sender;
	}

	public Email()
	{

	}
}
