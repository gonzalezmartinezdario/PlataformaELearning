﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ELearningPlatform.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
