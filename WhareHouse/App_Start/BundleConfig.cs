﻿using System.Web;
using System.Web.Optimization;

namespace WhareHouse
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Content/vendor/jquery/jquery.min.js",
                       "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                       "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                       "~/Content/vendor/chart.js/Chart.min.js",
                       "~/Content/vendor/datatables/jquery.dataTables.js",
                       "~/Content/vendor/datatables/dataTables.bootstrap4.js",
                       "~/Content/js/sb-admin.min.js",
                       "~/Content/js/demo/datatables-demo.js",
                       "~/Content/js/demo/chart-area-demo.js",
                       "~/Content/js/Customjs/Clock.js"
                       ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/Content/vendor/fontawesome-free/css/all.min.css",
                      "~/Content/vendor/datatables/dataTables.bootstrap4.css",
                      "~/Content/css/sb-admin.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/Customcss")
                      .IncludeDirectory("~/Content/css/CustomCss", "*.css"));
 
        }
    }
}
