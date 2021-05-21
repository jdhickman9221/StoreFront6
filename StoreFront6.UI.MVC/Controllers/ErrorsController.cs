
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreFront6.UI.MVC.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            //This view is for the admin -- it's also to display we are using them.
            //For final project you could even store the ability to let the admin update the output text for this view.
            return View();
        }//end index
        public ActionResult Throw404()
        {
            return View();
        }

        public ActionResult Unresolved()
        {
            return View();
        }
        public ActionResult SampleError()
        {
            int x = 0;
            int y = 42;
            int z = y / x;
            return View();
        }

       
        public ActionResult DBOffline()
        {
            return View();
        }
    }//end class
}//end namespace