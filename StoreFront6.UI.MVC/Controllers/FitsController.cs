using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront6.DATA.EF;

namespace StoreFront6.UI.MVC.Controllers
{
    public class FitsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Fits
        public ActionResult Index()
        {
            return View(db.Fits.ToList());
        }

        #region AJAX CRUD 

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AjaxDelete(int id)
        {
            Fit fit = db.Fits.Find(id);
            db.Fits.Remove(fit);
            db.SaveChanges();

            string confirmMessage = string.Format("Deleted size '{0}' from the database!", fit.FitName);
            return Json(new { id = id, message = confirmMessage });

        }

        //Details - Ajax Modal - this will get a partial view for details with AJAX display. Generate this view like normal but choose:
        //details scaffolding, check partial view box.
        [HttpGet]
        public PartialViewResult FitDetails (int id)
        {
            Fit fit = db.Fits.Find(id);
            return PartialView(fit);
        }

        //Create Fit
        [HttpPost]
        [ValidateAntiForgeryToken]//we need to do this to protect the data going in.
        public JsonResult AjaxCreate(Fit fit)
        {
            db.Fits.Add(fit);
            db.SaveChanges();
            return Json(fit);
        }
        
        //update / edit
        [HttpGet]
        public PartialViewResult FitEdit(int id)
        {
            Fit fit = db.Fits.Find(id);
            return PartialView(fit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxEdit(Fit fit)
        {
            db.Entry(fit).State = EntityState.Modified;
            db.SaveChanges();
            return Json(fit);
        }

        #endregion

        //// GET: Fits/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Fit fit = db.Fits.Find(id);
        //    if (fit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fit);
        //}

        //// GET: Fits/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Fits/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "FitID,FitName")] Fit fit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Fits.Add(fit);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(fit);
        //}

        //// GET: Fits/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Fit fit = db.Fits.Find(id);
        //    if (fit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fit);
        //}

        //// POST: Fits/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "FitID,FitName")] Fit fit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(fit).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(fit);
        //}

        //// GET: Fits/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Fit fit = db.Fits.Find(id);
        //    if (fit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fit);
        //}

        //// POST: Fits/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Fit fit = db.Fits.Find(id);
        //    db.Fits.Remove(fit);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

            
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
