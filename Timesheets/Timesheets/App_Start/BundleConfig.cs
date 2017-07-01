using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Timesheets.App_Start
{
    public class BundleConfig
    {
        public static void Register(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/Scripts/angular.js")
                .IncludeDirectory("~/Scripts", "*.js", searchSubdirectories: true)
                .IncludeDirectory("~/Client/Scripts", "*.js", searchSubdirectories: true));

            bundles.Add(new StyleBundle("~/bundles/styles")
                .IncludeDirectory("~/Content", "*.css", searchSubdirectories: true)
                .IncludeDirectory("~/Client/Styles", "*.css", searchSubdirectories: true));
        }
    }
}