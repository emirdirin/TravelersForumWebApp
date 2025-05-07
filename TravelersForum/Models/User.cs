using Microsoft.AspNetCore.Identity;

namespace Homework1.Models
{
	public class User:IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
	}
}
