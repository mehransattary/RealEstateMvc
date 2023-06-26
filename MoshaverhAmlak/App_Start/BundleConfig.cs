using System.Web;
using System.Web.Optimization;

namespace MoshaverhAmlak
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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/mycss").Include(
                   "~/Content/css/bootstrap.css",
                  "~/Content/css/style.css",
                  "~/Content/plugins/prettyphoto/css/prettyPhoto.css",
                  "~/Content/plugins/owl-carousel/css/owl.carousel.css",
                  "~/Content/plugins/owl-carousel/css/owl.theme.css",
                  "~/Content/colors/color1.css",
                  "~/Content/style-switcher/css/style-switcher.css"
                  ));
            bundles.Add(new ScriptBundle("~/Content/myjs").Include(
           "~/Content/js/jquery-2.0.0.min.js",
         "~/Content/plugins/prettyphoto/js/prettyphoto.js",
         "~/Content/plugins/owl-carousel/js/owl.carousel.min.js",
           "~/Content/plugins/flexslider/js/jquery.flexslider.js",
           "~/Content/js/helper-plugins.js",
           "~/Content/js/bootstrap.js",
          "~/Content/js/waypoints.js",
          "~/Content/js/init.js",
          "~/Content/style-switcher/js/jquery_cookie.js",
          "~/Content/style-switcher/js/script.js"
           ));



            bundles.Add(new StyleBundle("~/Content/myadmincss").Include(
          "~/Areas/Admin/assets/css/bootstrap-rtl.min.css",
         "~/Areas/Admin/assets/css/core.css",
         "~/Areas/Admin/assets/css/components.css",
          "~/Areas/Admin/assets/css/icons.css",
         "~/Areas/Admin/assets/css/pages.css",
          "~/Areas/Admin/assets/css/menu.css",
          "~/Areas/Admin/assets/css/responsive.css"
     
          ));

            bundles.Add(new ScriptBundle("~/Content/myadminjs").Include(
                 "~/Areas/Admin/assets/js/jquery.min.js",
                 "~/Areas/Admin/assets/js/bootstrap-rtl.min.js",
                 "~/Areas/Admin/assets/js/detect.js",
                 "~/Areas/Admin/assets/js/fastclick.js",
                 "~/Areas/Admin/assets/js/jquery.slimscroll.js",
                 "~/Areas/Admin/assets/js/jquery.blockUI.js",
                 "~/Areas/Admin/assets/js/waves.js",
                 "~/Areas/Admin/assets/js/jquery.nicescroll.js",
                 "~/Areas/Admin/assets/js/jquery.scrollTo.min.js",
                 "~/Areas/Admin/assets/js/jquery.core.js",
                 "~/Areas/Admin/assets/js/jquery.app.js"
            
             ));
            bundles.Add(new ScriptBundle("~/Content/myadminDatePersianjs").Include(
            "~/Areas/Admin/assets/MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker.js",
            "~/Areas/Admin/assets/MdBootstrapPersianDateTimePicker/jalaali.js"

            ));
            bundles.Add(new StyleBundle("~/Content/myadminDatePersiancss").Include(
              "~/Areas/Admin/assets/MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker.css"

            ));


        }

    }
}
