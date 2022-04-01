#nullable enable
namespace web_api_hello.Models
{
	public class User
	{

		public string? Gender { get; set; }
		public Name? Name { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public Picture? Picture { get; set; }
		public Location? Location { get; set; }

	}
}
