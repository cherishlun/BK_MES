using System.Web;
using System.Web.Optimization;

namespace BK_MES_MVC
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/H_css").Include(
                "~/Content/bootstrap.css"
                , "~/Content/font-awesome.css"
                , "~/Content/animate.css"
                , "~/Content/style.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/H_js").Include(
                "~/Scripts/jquery.min.js"
                , "~/Scripts/bootstrap.js"
                , "~/Scripts/plugins/metisMenu/jquery.metisMenu.js"
                , "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"
                , "~/Scripts/plugins/layer/layer.min.js"
                ));

            //easy ui 1.5.3
            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                      "~/Scripts/jquery.easyui.min.js"
                      , "~/Scripts/easyui-lang-zh_CN.js"));

            bundles.Add(new StyleBundle("~/Content/easyuicss").Include(
                  "~/Content/easyui/themes/bootstrap/easyui.css",
                  "~/Content/easyui/themes/icon.css"));

            //datagrid-filter
            bundles.Add(new ScriptBundle("~/bundles/easyui-datagrid-filter").Include(
                      "~/Scripts/datagrid-filter.js"));

            //表格，确认框
            bundles.Add(new ScriptBundle("~/bundles/table-alert").Include(
                      "~/Scripts/sweetalert.min.js"
                      , "~/Scripts/bootstrap-table/bootstrap-table.js"
                      , "~/Scripts/bootstrap-table/locale/bootstrap-table-zh-CN.js"
                      ));
      
           bundles.Add(new StyleBundle("~/Content/table-alert").Include(
                "~/Content/sweetalert.css"
                , "~/Scripts/bootstrap-table/bootstrap-table.css"));

            //验证
            bundles.Add(new ScriptBundle("~/bundles/bootstrapValidator").Include(
                      "~/Scripts/bootstrapValidator.js",
                      "~/Scripts/bootstrapValidator-zh-CN.js"
                      ));
            bundles.Add(new StyleBundle("~/Content/bootstrapValidator").Include(
                "~/Content/bootstrapValidator.css"));

        }
    }
}
