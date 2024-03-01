using System.Collections;
using Blazor.Data;

namespace Blazor.Services;

public interface IEmailService
{
	void SendEmail(Email email);
	ArrayList GetAllEmails();
}
