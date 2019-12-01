using PiProject.data;
using PiProject.domain.entities;
using PiProject.service;
using PiProject.web.Models.Collaborator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiProject.web.Controllers.manager
{
    public class ManagerController : Controller
    {


		private CollaboratorService _sr;
		private AnswerWebService _an;
		private PiServices _pi;




		public ManagerController()
		{
			this._sr = new CollaboratorService();
			this._an = new AnswerWebService();
			this._pi = new PiServices();
		}

		private static t_collaborator logger;

		[NonAction]
		public void Getlogger()
		{
			logger = (t_collaborator)Session["logger"];
		}
		// GET: Manager
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Dashboard()
		{
			Getlogger();
			return View();
		}

		public ActionResult DisplayWarnings()
		{

			List<Warning> ToConfirmList = _pi.GetAllWarningOfmanager(logger.C_ID);

			WarningModel warn; 
			List<WarningModel> warnList = new List<WarningModel>();

			foreach(Warning w in ToConfirmList)
			{
				warn = new WarningModel();
				warn.Reason = w.Reason;
				warn.Content = w.Content;
				warn.gravity = w.gravity;

				CollaboratorModel Towarn = new CollaboratorModel();
				Towarn.C_Forname = w.collab.C_Forname;
				Towarn.C_Lastname = w.collab.C_Lastname;
				warn.collabAffected = Towarn;

				warnList.Add(warn);
			}
			WarningListModel listModel = new WarningListModel();
			listModel.list = warnList;
			var model = listModel;

			return View("Warnings",model);
		}
	}
}