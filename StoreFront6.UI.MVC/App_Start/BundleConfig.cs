using System.Web.Optimization;

namespace StoreFront6.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Content/js/boostrap.min.js",
                      "~/Content/js/jquery-migrate-3.0.1.min.js",
                      "~/Content/js/jquery.animateNumber.min.js",
                      "~/Content/js/jquery.easing.1.3.js",
                      "~/Content/js/jquery.magnific-popup.min.js",
                      "~/Content/js/jquery.min.js",
                      "~/Content/js/jquery.stellar.min.js",
                      "~/Content/js/jquery.waypoints.min.js",
                      "~/Content/js/main.js",
                      "~/Content/js/owl.carousel.min.js",
                      "~/Content/js/popper.min.js",
                      "~/Content/js/scrollax.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css",
                      "~/Content/css/animate.css",
                      "~/Contentcss//bootstrap.min.css",
                      "~/Content/css/flaticon.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/owl.carosel.min.css",
                      "~/Content/css/owl.theme.default.min.css",
                      "~/Content/css/style.css",
                      "~/Content/css/css/CustomStyles.css",
                      "~/Content/css/boostrap-reboot.css",
                      "~/Content/css/boostrap-grid.css"));
        }
    }
}
