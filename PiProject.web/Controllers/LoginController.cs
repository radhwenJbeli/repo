using PiProject.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiProject.web.Controllers
{
    public class LoginController : Controller
    {
		private CollaboratorService _sr;

		public LoginController()
		{
			this._sr = new CollaboratorService();
		}

		// GET: Login
		public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult VerifyCredentials(FormCollection frm)
		{
			var Email = frm["email"].ToString();
			var Password = frm["password"].ToString();
			var logger = _sr.VerfyCredentials(Email, Password);
			Session["logger"] = logger;

			if (logger.t_manager != null)
				return RedirectToAction("Dashboard", "Manager", null);
			if (logger.t_developper != null) 
				return RedirectToAction("Dashboard", "Collaborator", null);
			

			return null;
		}

	}
}