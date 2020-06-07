using System;
using System.Linq;
using BookingSystem.Migrations;
using BookingSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookingSystemTests
{
	[TestClass]
	public class UserSystemTests
	{
		[TestMethod]
		public void CheckEqualPassword()
		{
			// arrange
			string password = "123456";
			string password2 = "123456";
			bool expected = password == password2;
			// act
			bool actual = UserSystem.GetInstance().IsEqualPasswords(password, password2);
			// assert
			Assert.AreEqual(expected, actual);
		}
	}
}
