using System.Web;
using System.Web.Optimization;

namespace Integration
{
    public class BundleConfig
    {
        const string assets = "~/assets/";
        const string styles = assets + "styles/";
        const string scripts = assets + "scripts/";

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            //Styles
            bundles.Add(new StyleBundle("~/css").Include(
                styles+"*bootstrap.css", 
                styles + "*main.css"
                ));
            bundles.Add(new StyleBundle("~/login_css").Include(styles+"login.css"));

            //Scripts
            bundles.Add(new ScriptBundle("~/js").Include(
                scripts+"bootstrap.js",
                scripts + "jquery-1.9.1.js",
                scripts + "main.js"
                ));
            bundles.Add(new ScriptBundle("~/registration_js").Include(
                 scripts+ "registration.js",
                 scripts + "jquery-1.9.1.js"));




        }
    }
}