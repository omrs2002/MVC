﻿using System.Web;
using System.Web.Optimization;

namespace MVCCourse2017
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                    "~/Scripts/DataTables/dataTables.bootstrap.js",
                    "~/scripts/typeahead.bundle.js",
                    "~/scripts/gridmvc.js",
                    "~/Scripts/toastr.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                  "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/content/typeahead.css",
                      "~/content/toastr.css",
                        "~/content/Gridmvc.css",
                      "~/Content/site.css"));
        }
    }
}
