using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreFront6.DATA.EF;
using System.Data;
using System.Data.Entity;




namespace StoreFront6.UI.MVC.Controllers
{

    public class FiltersController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Filters
        public ActionResult Index()
        {

            return View();
        }//end action
        public ActionResult JewleriesQS(string searchFilter)
        {
            return View();
        }

        //return all tunnels.
        public ActionResult GetTunnels()
        {
            var product = db.Jeweleries.Where(x => x.TypeID == 2).OrderBy(x => x.Price).ToList();
            return View(product);
        }

        //return all plugs.
        public ActionResult GetPlugs()
        {
            var product = db.Jeweleries.Where(x => x.TypeID == 1).OrderBy(x => x.Price).ToList();
            return View(product);
        }

        //return all hangers.
        public ActionResult GetHangers()
        {
            var product = db.Jeweleries.Where(x => x.TypeID == 7).OrderBy(x => x.Price).ToList();
            return View(product);
        }

        //return all clickers.
        public ActionResult GetClickers()
        {
            var product = db.Jeweleries.Where(x => x.TypeID == 4).OrderBy(x => x.Price).ToList();
            return View(product);
        }

        //return all stacks.
        public ActionResult GetStacks()
        {
            var product = db.Jeweleries.Where(x => x.TypeID == 3).OrderBy(x => x.Price).ToList();
            return View(product);
        }

        //return all hoops
        public ActionResult GetHoops()
        {
            var product = db.Jeweleries.Where(x => x.TypeID == 5).OrderBy(x => x.Price).ToList();
            return View(product);
        }
    }//end class
}//end namespace