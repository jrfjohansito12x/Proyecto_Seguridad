using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Seguridad.Controllers
{
    public class SalirController : Controller
    {
        public ActionResult Index()
        {
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }
    }
}