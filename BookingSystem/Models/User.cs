using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
	public class User
	{
		[Column(TypeName = "int")]
		public int Id { get; set; }
		[Column(TypeName = "nvarchar(max)")]
		public string Login { get; set; }
		[Column(TypeName = "nvarchar(max)")]
		public string Password { get; set; }
		[Column(TypeName = "bit")]
		public bool IsAdmin { get; set; }
		[Column(TypeName = "nvarchar(max)")]
		public string Email { get; set; }
	}
}