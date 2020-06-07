using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BookingSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookingSystemTests
{
	[TestClass]
	public class PasswordCheckTests
	{
		[TestMethod]
		public void CheckHasNumber()
		{
			// arrange
			string password = "P@ssw0rd";
			bool expected = new PasswordCheck().CheckHasNumber(password);
			// act
			bool actual = new Regex(@"[0-9]+").IsMatch(password);
			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CheckUpperChar()
		{
			// arrange
			string password = "P@ssw0rd";
			bool expected = new PasswordCheck().CheckUpperChar(password);
			// act
			bool actual = new Regex(@"[A-Z]+").IsMatch(password);
			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CheckMinimum8Chars()
		{
			// arrange
			string password = "P@ssw0rd";
			bool expected = new PasswordCheck().CheckMinimumNChars(password, 8);
			// act
			bool actual = new Regex(@".{8,}").IsMatch(password);
			// assert
			Assert.AreEqual(expected, actual);
		}
	}
}
