using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Description;
using BookingSystem.Models;

namespace BookingSystem.Controllers
{
	public class HomeController : Controller
	{
		protected UserSystem UserSystem { get; }

		public HomeController()
		{
			UserSystem = UserSystem.GetInstance();
		}
		public ActionResult Index()
		{
			ViewBag.IsHome = true;
			return View();
		}

		public ActionResult SignIn()
		{
			ViewBag.IsSignIn = true;
			return View();
		}

		[HttpPost]
		public ActionResult CheckLogin(string login, string password)
		{
			var user = UserSystem.GetUser(login, password);
			if (user != null)
			{
				Session["User"] = user;
				return RedirectToAction("Index");
			}
			else
			{
				Session["ErrorMessage"] = "Не вірний логін або пароль!";
				return RedirectToAction("SignIn");
			}
		}

		[HttpPost]
		public ActionResult GoRegistration(string login, string password, string password2, string email)
		{
			if (UserSystem.CheckLogin(login))
			{
				Session["ErrorMessage"] = $"Користувач {login} вже існує!";
				Session["Login"] = login;
				Session["Email"] = email;
			}
			else if (UserSystem.CheckEmail(email))
			{
				Session["ErrorMessage"] = $"{email} вже існує!";
				Session["Login"] = login;
				Session["Email"] = email;
			}
			else if (password != password2)
			{
				Session["ErrorMessage"] = "Паролі не співпадають!";
				Session["Login"] = login;
				Session["Email"] = email;
			}
			else
			{
				UserSystem.NewUsers(new User()
				{
					Login = login,
					Password = password,
					Email = email
				});
				Session["Message"] = "Успішно створений, можеш авторизуватися!";
			}
			return RedirectToAction("SignOut");
		}

		public ActionResult SignOut()
		{
			ViewBag.IsSignOut = true;
			return View();
		}

		public ActionResult Exit()
		{
			Session["User"] = null;
			return RedirectToAction("Index");
		}
		public ActionResult Profile()
		{
			return RedirectToAction("Index");
		}

		public void Main()
		{
			var newUser = new User();

			var userSystem = UserSystem.GetInstance();
			userSystem.NewUsers(newUser);


			var userSystem2 = UserSystem.GetInstance();
			userSystem2.NewUsers(newUser);
		}
	}
}