using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreFront6.DATA.EF/*.Metadata*/
{
    #region Fit
    [MetadataType(typeof(FitMetaData))]
    public partial class Fit { }
    public class FitMetaData
    {
        [Required(ErrorMessage = "* Size is required")]
        public int FitID { get; set; }


        [Required(ErrorMessage = "* Size is required")]
        [StringLength(14, ErrorMessage = "* Must not exceed 14 characters")]
        [Display(Name = "Size")]
        public string FitName { get; set; }
    }
    #endregion

    #region InvStatus
    [MetadataType(typeof(InvStatuMetaData))]
    public partial class InvStatu { }
    public class InvStatuMetaData
    {
        [Required(ErrorMessage = "* Inventory Status Required")]
        public int InvID { get; set; }


        [Required(ErrorMessage = "* Inventory Status Required")]
        [StringLength(20, ErrorMessage = "* Must not exceed 20 characters")]
        [Display(Name = "Product Status")]
        public string InvName { get; set; }
    }

    #endregion

    #region Jewelery
    public class JeweleryMetadata
    {
        //public int ProductID { get; set; }//DB will auto increment this.

        [Required(ErrorMessage = "* Product must have name.")]
        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "* Material is required.")]
        [Display(Name = "Material")]
        public int MaterialID { get; set; }

        [Required(ErrorMessage = "* Jewelery size is required.")]
        [Display(Name = "Size")]
        public Nullable<int> FitID { get; set; }

        [Required(ErrorMessage = "* Inventory status required.")]
        [Display(Name = "Product Status")]
        public int InvID { get; set; }

        [Required(ErrorMessage = "* Jewelery style is required.")]
        [Display(Name = "Style")]
        public Nullable<int> TypeID { get; set; }

        [Required(ErrorMessage = "* Supplier is required.")]
        [Display(Name = "Supplier")]
        public int SupplierID { get; set; }


        [Display(Name = "Pairs Sold")]
        public int UnitsSold { get; set; }

        [Display(Name = "Release Date")]
        public Nullable<System.DateTime> ReleaseDate { get; set; }


        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "* Product description required")]
        [Display(Name = "Description")]
        [StringLength(100, ErrorMessage = "* Must not exceed 100 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "* Sold-as-pair is required.")]
        [Display(Name = "Sold as a pair?")]
        public Nullable<bool> SoldAsPair { get; set; }


        [Required(ErrorMessage = "* Price is required.")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:c}", NullDisplayText = "[NA]")]
        public Nullable<decimal> Price { get; set; }
    }

    [MetadataType(typeof(JeweleryMetadata))]
    public partial class Jewelery
    {

    }

    #endregion

    #region Material
    [MetadataType(typeof(MaterialMetaData))]
    public partial class Material { }
    public class MaterialMetaData
    {
        [Required(ErrorMessage = "* Material is required.")]
        [Display(Name = "Material")]
        public int MaterialID { get; set; }

        [Required(ErrorMessage = "* Material is required.")]
        [Display(Name = "Material")]
        [StringLength(100, ErrorMessage = "* Must not exceed 50 characters")]
        public string MaterialName { get; set; }
        //required doesn't function
    }
    #endregion

    #region Supplier
    [MetadataType(typeof(SupplierMetaData))]
    public partial class Supplier { }
    public class SupplierMetaData
    {
        [Required(ErrorMessage = "* Supplier Must Be Listed")]
        [Display(Name = "Supplier")]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "* Supplier Must Be Listed")]
        [Display(Name = "Supplier Name")]
        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "* City Required")]
        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "* State Required")]
        [Display(Name = "State")]
        [StringLength(2, ErrorMessage = "* Must not exceed 2 characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "* Phone required")]
        [Display(Name = "Phone")]
        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        public string Phone { get; set; }
    }

    #endregion

    #region Type
    [MetadataType(typeof(TypeMetaData))]
    public partial class Type { }
    public class TypeMetaData
    {
        [Required(ErrorMessage = "* Style Name Required")]
        [Display(Name = "Style")]
        public int TypeID { get; set; }

        [Required(ErrorMessage = "* Style Name Required")]
        [Display(Name = "Style")]
        [StringLength(20, ErrorMessage = "* Must not exceed 20 characters")]
        public string TypeName { get; set; }
    }

    #endregion

    #region Contact

    #endregion


}
