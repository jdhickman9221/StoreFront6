using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreFront6.DATA.EF;
using StoreFront6.UI.MVC.Models;

namespace StoreFront6.UI.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            if (shoppingCart == null || shoppingCart.Count==0)
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
                ViewBag.Message = "your cart is empty";
            }
            else
            {
                ViewBag.Message = null;
            }
            return View(shoppingCart);
        }//end action
        public ActionResult UpdateCart(int productID, int qty)
        {
            if(qty == 0)
            {
                RemoveFromCart(productID);
                return RedirectToAction("Index");
            }
            Dictionary<int, CartItemViewModel> shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            shoppingCart[productID].Qty = qty;
            Session["cart"] = shoppingCart;

            if (shoppingCart.Count == 0)
            {
                ViewBag.Message = "There are no books in your cart";
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            Dictionary<int, CartItemViewModel> shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            shoppingCart.Remove(id);

            if (shoppingCart.Count == 0)
            {
                Session["cart"] = null;
            }
            return RedirectToAction("Index");
        }
    }//end class
}//end namespace