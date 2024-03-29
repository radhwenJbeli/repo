﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiProject.web.Models.Login
{
	public class LoggerModel 
	{
		[Required(ErrorMessage = "Required")]
		public string email { get; set; }
		[Required(ErrorMessage = "Required")]
		public string password { get; set; }
	}
}