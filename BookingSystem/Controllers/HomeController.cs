using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BookingSystem.Models;

namespace BookingSystem.Controllers
{
	public class HomeController : Controller
	{
		protected Authorization Authorization { get; set; }
		public ActionResult Index()
		{
			ViewBag.IsHome = true;
			return View();
		}

		public ActionResult SignIn(string message = null)
		{
			ViewBag.IsSignIn = true;
			ViewBag.Message = message;
			return View();
		}

		[HttpPost]
		public ActionResult CheckLogin(string login, string password)
		{
			Authorization = Authorization.GetInstance();
			return Authorization.CheckUser(login, password)
				? RedirectToAction("Index")
				: RedirectToAction("SignIn", new
				{
					message = "Не вірний логін або пароль!"
				});
		}

		public ActionResult SignOut()
		{
			ViewBag.IsSignOut = true;
			return View();
		}
	}
}