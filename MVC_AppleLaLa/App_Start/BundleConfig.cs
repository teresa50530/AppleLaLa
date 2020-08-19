using System.Web;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace MVC_AppleLaLa
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            //bundles.Add(new StyleBundle("~/Assets/css").Include(
            //     "~/Assets/css/bootstrap.min.css",
            //     "~/Assets/css/font-awesome.min.css",
            //     "~/Assets/css/jquery-ui.min.css",
            //     //"~/Assets/css/flaticon.css", 好像要裝插件先註解掉
            //     "~/Assets/css/owl.carousel.css",
            //     "~/Assets/css/style.css",
            //     "~/Assets/css/animate.css",
            //     "~/Assets/css/solid.min.css",
            //     "~/Assets/css/brands.min.css"
            //    ));
            //bundles.Add(new StyleBundle("~/Assets/js").Include(
            //    "~/Assets/js/jquery-3.2.1.min.js",
            //    "~/Assets/js/jquery-ui.min.js",
            //    "~/Assets/js/bootstrap.min.js",
            //    "~/Assets/js/owl.carousel.min.js",
            //    "~/Assets/js/circle-progress.min.js",
            //    "~/Assets/js/main.js",
            //    "~/Assets/js/fontawesome.min.js",
            //    "~/Assets/js/solid.min.js",
            //    "~/Assets/js/brands.min.js"
            //    ));
        }
    }
}
