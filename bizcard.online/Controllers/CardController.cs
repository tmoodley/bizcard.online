﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bizcard.online.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index(string id)
        {
            
            return View();
        }
    }
}