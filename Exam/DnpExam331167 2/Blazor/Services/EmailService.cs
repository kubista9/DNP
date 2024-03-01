using System.Collections;
using System.Text.Json;
using Blazor.Data;

namespace Blazor.Services;

public class EmailService : IEmailService

{
	private static ArrayList Emails = new ArrayList();

	public EmailService()
	{

	}
	public void SendEmail(Email email)
	{
		Emails.Add(email);
	}

	public ArrayList GetAllEmails()
	{
		return Emails;
	}
}
