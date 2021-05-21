using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront6.DATA.EF;
//Added these for MVC3 file upload.
using StoreFront6.UI.MVC.Utilities;
using System.Drawing;
using PagedList;
using PagedList.Mvc;
using StoreFront6.UI.MVC.Models;
//Page List Step 2: added for paging:


namespace StoreFront6.UI.MVC.Controllers
{
    public class JeweleriesController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        //// GET: Jeweleries
        //public ActionResult Index()
        //{
        //    var jeweleries = db.Jeweleries.Include(j => j.Fit).Include(j => j.InvStatu).Include(j => j.Material).Include(j => j.Supplier).Include(j => j.Type);
        //    return View(jeweleries.ToList());
        //}

        //Grid View Step 1: Create new list object called Jeweleries, use a query string in linq go innerjoin these tables.
        //Page List Step 1: Add through NuGet pacakge PagedList.MVC, select yes to all, you can also add the CSS to layout. Create Filters Controller. 
        public ActionResult JeweleriesGrid(string searchFilter)
        {

            //List<Jewelery> jeweleries = db.Jeweleries.Include(j => j.Fit).Include(j => j.InvStatu).Include(j => j.Material).Include(j => j.Supplier).Include(j => j.Type).ToList();
            if (String.IsNullOrEmpty(searchFilter))
            {
                var jeweleries = db.Jeweleries;
                return View(jeweleries.ToList());
            }
            else
            {
                string searchUpCase = searchFilter.ToUpper();
                List<Jewelery> searchResults = db.Jeweleries.Where(a => a.ProductName.ToUpper().Contains(searchUpCase) || a.Material.MaterialName.ToUpper().Contains(searchUpCase) || a.Type.TypeName.ToUpper().Contains(searchUpCase)).ToList();
                return View(searchResults);
            }
            
        }

        public ActionResult JeweleryMVCPaging(int page = 1)
        {
            //how many records per page?
            int pageSize = 5;
            var jewelery = db.Jeweleries.OrderBy(j => j.ProductName).ToList();
            return View(jewelery.ToPagedList(page, pageSize));
        }

        // GET: Jeweleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelery jewelery = db.Jeweleries.Find(id);
            if (jewelery == null)
            {
                return HttpNotFound();
            }
            return View(jewelery);
        }

        // GET: Jeweleries/Create
        public ActionResult Create()
        {
            ViewBag.FitID = new SelectList(db.Fits, "FitID", "FitName");
            ViewBag.InvID = new SelectList(db.InvStatus, "InvID", "InvName");
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "TypeName");
            return View();
        }

        // POST: Jeweleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,MaterialID,FitID,InvID,TypeID,SupplierID,UnitsSold,ReleaseDate,ProductImage,Description,SoldAsPair,Price")] Jewelery jewelery, HttpPostedFileBase ProductImage)
        {
            #region File Upload
            string imageName = "noImage.png";
            if (ProductImage != null)
            {
                imageName = ProductImage.FileName;
                string ext = imageName.Substring(imageName.LastIndexOf("."));
                string[] goodExts = new string[] { ".jpeg", ".jpg", ".png", ".gif" };
                if (goodExts.Contains(ext.ToLower()) && ProductImage.ContentLength <= 4194304)
                {
                    imageName = Guid.NewGuid() + ext;
                    //ProductImage.SaveAs(Server.MapPath("~/Content/images/products/" + imageName));

                    #region Resize Image
                    string savePath = Server.MapPath("~/Content/images/products/");
                    Image convertedImage = Image.FromStream(ProductImage.InputStream);
                    int maxImageSize = 500;
                    int maxThumbSize = 150;
                    ImageUtility.ResizeImage(savePath, imageName, convertedImage, maxImageSize, maxThumbSize);
                    #endregion
                }
            }
            jewelery.ProductImage = imageName;
            #endregion
            if (ModelState.IsValid)
            {
                db.Jeweleries.Add(jewelery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FitID = new SelectList(db.Fits, "FitID", "FitName", jewelery.FitID);
            ViewBag.InvID = new SelectList(db.InvStatus, "InvID", "InvName", jewelery.InvID);
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName", jewelery.MaterialID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", jewelery.SupplierID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "TypeName", jewelery.TypeID);
            return View(jewelery);
        }

        // GET: Jeweleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelery jewelery = db.Jeweleries.Find(id);
            if (jewelery == null)
            {
                return HttpNotFound();
            }
            ViewBag.FitID = new SelectList(db.Fits, "FitID", "FitName", jewelery.FitID);
            ViewBag.InvID = new SelectList(db.InvStatus, "InvID", "InvName", jewelery.InvID);
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName", jewelery.MaterialID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", jewelery.SupplierID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "TypeName", jewelery.TypeID);
            return View(jewelery);
        }

        // POST: Jeweleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,MaterialID,FitID,InvID,TypeID,SupplierID,UnitsSold,ReleaseDate,ProductImage,Description,SoldAsPair,Price")] Jewelery jewelery, HttpPostedFileBase ProductImage)//
        {

            //1. So we know when editing, the JeweleryImage already has a string val in place. Whether its default no image or the one uploaded.
            //We need to add HttpPostedFileBase for this Edit so uploading files are accepted in the Edit.
            //2. Check the input and see if something was uploaded. With an If.
            //3. create a string var with the value of ProductImage prop's file name through HttpPostedFileBase.
            //4. Grab the file ext and store it in a variable through substring.
            //5. Create a new string array of acceptable file exts so we can compare what the user uploaded to them.
            //6. Compare the file ext with the new array of acceptable exts.
            //7. If the file name ext matches a good ext, rename the file to a new guid. We want these to be unique. 
            //8. Save as to push the file to the server files, you have to provide a Server.MapPath.
            //9. Because we are in edit, we have to delete the previous assosiated image from the web server.
            //10. We use System Input Output File Delete.

            if (ProductImage != null)
            {
                string imageName = ProductImage.FileName;//we made a string var with the val of ProductImage prop File Name from HttpPostedFileBase.
                string ext = imageName.Substring(imageName.LastIndexOf("."));//isolated just the ext of the file uploaded.
                string[] goodExts = new string[] { ".jpeg", ".jpg", ".png", ".gif" };

                if (goodExts.Contains(ext.ToLower()) && ProductImage.ContentLength <= 4194304)
                {
                    imageName = Guid.NewGuid() + ext;
                    #region Resize Image
                    string savePath = Server.MapPath("~/Content/images/products/");
                    Image convertedImage = Image.FromStream(ProductImage.InputStream);
                    int maxImageSize = 500;
                    int maxThumbSize = 150;
                    ImageUtility.ResizeImage(savePath, imageName, convertedImage, maxImageSize, maxThumbSize);
                    #endregion
                    //ProductImage.SaveAs(Server.MapPath("~/Content/images/products/" + imageName));

                    string currentFile = Request.Params["ProductImage"];
                    if (currentFile != "noImage.png" && currentFile != null)
                    {
                        string path = (Server.MapPath("~/Content/images/products/"));
                        ImageUtility.Delete(path, jewelery.ProductImage);
                        //System.IO.File.Delete(Server.MapPath("~/Content/images/products/" + currentFile));
                    }
                }
                jewelery.ProductImage = imageName;

            }
            if (ModelState.IsValid)
            {
                db.Entry(jewelery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FitID = new SelectList(db.Fits, "FitID", "FitName", jewelery.FitID);
            ViewBag.InvID = new SelectList(db.InvStatus, "InvID", "InvName", jewelery.InvID);
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName", jewelery.MaterialID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", jewelery.SupplierID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "TypeName", jewelery.TypeID);
            return View(jewelery);
        }

        // GET: Jeweleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelery jewelery = db.Jeweleries.Find(id);
            if (jewelery == null)
            {
                return HttpNotFound();
            }
            return View(jewelery);
        }

        // POST: Jeweleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Jewelery jewelery = db.Jeweleries.Find(id);
            if (jewelery.InvID != 2)
            {
                if (jewelery.ProductImage != "noImage.png" && jewelery.ProductImage != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Content/images/products/" + jewelery.ProductImage));
                }
                jewelery.InvID = 2;
            }
            else
            {
                jewelery.ProductImage = "noImage.png";
                jewelery.InvID = 1;
            }

            db.Entry(jewelery).State = EntityState.Modified;
            db.SaveChanges();


            //db.Jeweleries.Remove(jewelery);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Jeweleries/Delete/5
        public ActionResult HardDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelery jewelery = db.Jeweleries.Find(id);
            if (jewelery == null)
            {
                return HttpNotFound();
            }
            return View(jewelery);
        }
        // POST: Jewelery/Delete/5
        [HttpPost, ActionName("HardDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult HardDeleteConfirmed(int id)
        {
            Jewelery jewelery = db.Jeweleries.Find(id);
            db.Jeweleries.Remove(jewelery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #region Add To Cart
        public ActionResult AddToCart(int qty, int productID)
        {
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            if (Session["cart"] != null)
            {
                shoppingCart=(Dictionary<int, CartItemViewModel>)Session["cart"];
            }
            else
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }
            Jewelery product = db.Jeweleries.Where(j => j.ProductID == productID).FirstOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                CartItemViewModel item = new CartItemViewModel(qty, product);
                if (shoppingCart.ContainsKey(product.ProductID))
                {
                    shoppingCart[product.ProductID].Qty += qty;
                }
                else
                {
                    shoppingCart.Add(product.ProductID, item);
                }
                Session["cart"] = shoppingCart;
            }
                return RedirectToAction("Index", "ShoppingCart");
        }
        #endregion

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
