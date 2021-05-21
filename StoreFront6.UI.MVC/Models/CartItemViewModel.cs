using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using StoreFront6.DATA.EF;
//cart step 1: right click models folder, add class
//cart step 2: Add using statements to the file for your data project layer and data annotations.

namespace StoreFront6.UI.MVC.Models
{
    public class CartItemViewModel
    {
        [Range(1, int.MaxValue)]//ensure the values of QTY are greater than zero.
        public int Qty { get; set; }
        public Jewelery Product {get; set;}
        //ctors
        public CartItemViewModel(int qty, Jewelery product)
        {
            Qty = qty;
            Product = product;
        }//end method
    }//end class
}//end namespace