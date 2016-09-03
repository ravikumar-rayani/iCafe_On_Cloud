using System.Web;
using System.Web.Optimization;

namespace iCafe.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts
            bundles.Add(new ScriptBundle("~/bundles/jqueryscripts").Include(
                      "~/plugins/jquery-ui/jquery-ui.min.js"
                    , "~/plugins/jquery-blockui/jquery.blockui.js"
                    , "~/plugins/jquery-slimscroll/jquery.slimscroll.min.js"
                    , "~/plugins/jquery-counterup/jquery.counterup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapscripts").Include(                
                      "~/plugins/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/flotscripts").Include(
                      "~/plugins/flot/jquery.flot.min.js"
                    , "~/plugins/flot/jquery.flot.time.min.js"
                    , "~/plugins/flot/jquery.flot.symbol.min.js"
                    , "~/plugins/flot/jquery.flot.resize.min.js"
                    , "~/plugins/flot/jquery.flot.tooltip.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/offcanvasscripts").Include(            
                      "~/plugins/offcanvasmenueffects/js/classie.js"
                    , "~/plugins/offcanvasmenueffects/js/main.js"
                    , "~/plugins/offcanvasmenueffects/js/snap.svg-min.js"));

            bundles.Add(new ScriptBundle("~/bundles/3d-boldscripts").Include(
                      "~/plugins/3d-bold-navigation/js/main.js"                    
                    , "~/plugins/3d-bold-navigation/js/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/otherpluginscripts").Include(
                      "~/plugins/pace-master/pace.min.js"
                    , "~/plugins/switchery/switchery.min.js"
                    , "~/plugins/uniform/jquery.uniform.min.js"
                    , "~/plugins/waves/waves.min.js"
                    , "~/plugins/waypoints/jquery.waypoints.min.js"
                    , "~/plugins/toastr/toastr.min.js"                    
                    , "~/plugins/curvedlines/curvedLines.js"
                    , "~/plugins/metrojs/MetroJs.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/appscripts").Include(
                    "~/Scripts/ultrascripts.js"
                    , "~/Scripts/modern.js"
                    , "~/Scripts/pages/dashboard.js"
                    , "~/Scripts/pages/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/loginscripts").Include(
                    "~/plugins/jquery/jquery-2.1.3.min.js"
                    , "~/Scripts/login/prefixfree.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/galleryscripts").Include(
                    "~/plugins/perfect-scrollbar/perfect-scrollbar.min.js"
                    , "~/plugins/prettyphoto/jquery.prettyPhoto.js"));

            //bundles.Add(new ScriptBundle("~/bundles/datatablescripts").Include(
            //        "~/plugins/datatables/js/jquery.dataTables.min.js")); 

            bundles.Add(new ScriptBundle("~/bundles/datatablescripts").Include(
                      "~/plugins/jquery-mockjax-master/jquery.mockjax.js"
                    , "~/plugins/datatables/js/jquery.datatables.min.js"
                    , "~/plugins/x-editable/bootstrap3-editable/js/bootstrap-editable.js"
                    , "~/Scripts/pages/table-data.js"));
            
            //bundles.Add(new ScriptBundle("~/bundles/datatablescripts").Include(
            //        "~/Scripts/datatables/jquery.dataTables.min.js"
            //        , "~/Scripts/datatables/dataTables.bootstrap.js"
            //        , "~/Scripts/datatables/jquery.dataTables.yadcf.js"
            //        , "~/Scripts/datatables/dataTables.tableTools.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/imagegridscripts").Include(
                    "~/plugins/jRespond/jRespond.min.js"
                    , "~/plugins/animsition/js/jquery.animsition.min.js"
                    , "~/plugins/magnific-popup/jquery.magnific-popup.min.js"
                    , "~/plugins/mixitup/jquery.mixitup.min.js")); 

            #endregion

            #region Styles
            bundles.Add(new StyleBundle("~/Content/bootstrapstyles").Include(                    
                      "~/plugins/bootstrap/css/bootstrap.min.css"
                      , "~/plugins/bootstrap/css/bootstrap.css"
                ));

            bundles.Add(new StyleBundle("~/Content/bootstrapextendstyles").Include(
                      "~/plugins/bootstrap/css/bootstrap-extend.min.css"));

            bundles.Add(new StyleBundle("~/Content/otherpluginstyles").Include(
                      "~/plugins/pace-master/themes/blue/pace-theme-flash.css"
                    , "~/plugins/uniform/css/uniform.default.min.css"
                    , "~/plugins/fontawesome/css/font-awesome.css"
                    , "~/plugins/line-icons/simple-line-icons.css"	
                    , "~/plugins/offcanvasmenueffects/css/menu_cornerbox.css"	
                    , "~/plugins/waves/waves.min.css"	
                    , "~/plugins/switchery/switchery.min.css"
                    , "~/plugins/3d-bold-navigation/css/style.css"
                    , "~/plugins/slidepushmenus/css/component.css"	
                    , "~/plugins/weather-icons-master/css/weather-icons.min.css"	
                    , "~/plugins/metrojs/MetroJs.min.css"
                    , "~/plugins/toastr/toastr.min.css"));

            bundles.Add(new StyleBundle("~/Content/appstyles").Include(
                      "~/Content/modern.css"
                    , "~/Content/custom.css"));

            bundles.Add(new StyleBundle("~/Content/loginstyles").Include(
                "~/Content/login/login-style.css"));

            bundles.Add(new StyleBundle("~/Content/gallerystyles").Include(
                      "~/plugins/pace/pace-theme-flash.css"
                    , "~/plugins/prettyphoto/prettyPhoto.css"));

            bundles.Add(new StyleBundle("~/Content/datatablestyles").Include(
                      "~/plugins/datatables/css/jquery.dataTables.css"));

            bundles.Add(new StyleBundle("~/Content/datatablestyles").Include(
                    "~/plugins/bootstrap/css/bootstrap.min.css"
                    , "~/plugins/datatables/css/jquery.datatables.min.css"
                    , "~/plugins/x-editable/bootstrap3-editable/css/bootstrap-editable.css"
                    , "~/plugins/bootstrap-datepicker/css/datepicker3.css"
                    , "~/Content/modern.min.css"));

            //bundles.Add(new StyleBundle("~/Content/datatablestyles").Include(
            //          "~/Content/xenon-core.css"
            //          , "~/plugins/fontawesome/css/font-awesome.min.css"
            //          ));

            bundles.Add(new StyleBundle("~/Content/imagegridstyles").Include(
                      "~/Content/image-grid.css"
                      , "~/plugins/magnific-popup/magnific-popup.css"));
            #endregion
        }
    }
}
