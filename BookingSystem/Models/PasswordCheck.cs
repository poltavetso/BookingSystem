using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BookingSystem.Models
{
	public class PasswordCheck
	{
		public bool Check(string input)
		{
			return CheckHasNumber(input) && CheckUpperChar(input) && CheckMinimumNChars(input, 8);
		}

		public bool CheckHasNumber(string input)
		{
			var hasNumber = new Regex(@"[0-9]+");
			return hasNumber.IsMatch(input);
		}

		public bool CheckUpperChar(string input)
		{
			var hasUpperChar = new Regex(@"[A-Z]+");
			return hasUpperChar.IsMatch(input);
		}

		public bool CheckMinimumNChars(string input, int n)
		{
			var hasMinimumNChars = new Regex(@".{" + n + ",}");
			return hasMinimumNChars.IsMatch(input);
		}
	}
}