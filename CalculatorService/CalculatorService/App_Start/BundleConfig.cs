using System.Web.Optimization;

namespace CalculatorService
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libraries").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Scripts/CalculatorStyles/calculator.min.css"));

            bundles.Add(new ScriptBundle("~/scripts/addition").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/CalculatorScripts/commonActions.js",
                        "~/Scripts/CalculatorScripts/addition/addition.js"));
            
            bundles.Add(new ScriptBundle("~/scripts/substraction").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/CalculatorScripts/commonActions.js",
                        "~/Scripts/CalculatorScripts/substraction/substraction.js"));

            bundles.Add(new ScriptBundle("~/scripts/multiplication").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/CalculatorScripts/commonActions.js",
                        "~/Scripts/CalculatorScripts/multiplication/multiplication.js"));

            bundles.Add(new ScriptBundle("~/scripts/division").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/CalculatorScripts/commonActions.js",
                        "~/Scripts/CalculatorScripts/division/division.js"));

            bundles.Add(new ScriptBundle("~/scripts/squareRoot").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/CalculatorScripts/commonActions.js",
                        "~/Scripts/CalculatorScripts/squareRoot/squareRoot.js"));

            bundles.Add(new ScriptBundle("~/scripts/query").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/CalculatorScripts/commonActions.js",
                        "~/Scripts/CalculatorScripts/query/query.js"));
        }
    }
}
