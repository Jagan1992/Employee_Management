using System.Web;
using System.Web.Optimization;

namespace EmployeeManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery-3.3.1.js",
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.semanticui.min.js",
                "~/Scripts/DataTables/semantic.min.js",
                "~/Scripts/typeahead.bundle.min.js"
                 ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.min.css",
                "~/Content/bootstrap-lumen.min.css",
                "~/Content/DataTables/css/semantic.min.css",
                "~/Content/DataTables/css/dataTables.semanticui.min.css",
                "~/Content/typeahead.css"));
        }
    }
}
