using System.Web;
using System.Web.Optimization;

namespace ClienteSeguridad
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            // Vendor scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.min.js"));

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate.min.js"));

            // jQueryUI CSS
            bundles.Add(new ScriptBundle("~/Scripts/plugins/jquery-ui/jqueryuiStyles").Include(
                        "~/Scripts/plugins/jquery-ui/jquery-ui.min.css"));
            // jQueryUI 
            bundles.Add(new StyleBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/plugins/jquery-ui/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                      "~/Scripts/plugins/metisMenu/metisMenu.min.js",
                      "~/Scripts/plugins/pace/pace.min.js",
                      "~/Scripts/app/inspinia.js"));

            // Inspinia skin config script
            bundles.Add(new ScriptBundle("~/bundles/skinConfig").Include(
                      "~/Scripts/app/skin.config.min.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                      "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js"));

            // jQuery plugins
            bundles.Add(new ScriptBundle("~/plugins/metsiMenu").Include(
                      "~/Scripts/plugins/metisMenu/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/plugins/pace").Include(
                      "~/Scripts/plugins/pace/pace.min.js"));

            bundles.Add(new ScriptBundle("~/plugins/toastr").Include(
                      "~/Scripts/plugins/toastr/toastr.min.js"));

            bundles.Add(new StyleBundle("~/plugins/toastrStyles").Include(
                      "~/Content/plugins/toastr/toastr.min.css"));

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/style.css",
                      "~/Content/plugins/dataTables/datatables.min.css",
                      "~/Content/plugins/sweetalert/sweetalert.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/fonts/font-awesome/css/fontawesome-all.min.css", new CssRewriteUrlTransform()));


            // dataTables JS
            bundles.Add(new ScriptBundle("~/plugins/dataTables").Include(
                      "~/Scripts/plugins/dataTables/datatables.min.js"));




            // jsTree styles  2
            bundles.Add(new ScriptBundle("~/plugins/chartist").Include(
                      "~/Scripts/plugins/chartist/chartist.min.js"));

            // sweetalert JS
            bundles.Add(new ScriptBundle("~/plugins/sweetalert").Include(
                      "~/Scripts/plugins/sweetalert/sweetalert.min.js"));

            // dataPicker styles
            bundles.Add(new StyleBundle("~/plugins/dataPickerStyles").Include(
                      "~/Content/plugins/datapicker/datepicker3.css"));

            // dataPicker 
            bundles.Add(new ScriptBundle("~/plugins/dataPicker").Include(
                      "~/Scripts/plugins/datapicker/bootstrap-datepicker.js",
                      "~/Scripts/plugins/datapicker/locales/bootstrap-datepicker.es.js"));

            // Clockpicker styles
            bundles.Add(new StyleBundle("~/plugins/clockpickerStyles").Include(
                      "~/Content/plugins/clockpicker/clockpicker.css"));

            // Clockpicker
            bundles.Add(new ScriptBundle("~/plugins/clockpicker").Include(
                      "~/Scripts/plugins/clockpicker/clockpicker.js"));

            // iCheck css styles
            bundles.Add(new StyleBundle("~/Content/plugins/iCheck/iCheckStyles").Include(
                      "~/Content/plugins/iCheck/custom.css"));

            // iCheck
            bundles.Add(new ScriptBundle("~/plugins/iCheck").Include(
                      "~/Scripts/plugins/iCheck/icheck.min.js"));

            // fullCalendar styles
            bundles.Add(new StyleBundle("~/plugins/fullCalendarStyles").Include(
                      "~/Content/plugins/fullcalendar/fullcalendar.css"));

            // fullCalendar 
            bundles.Add(new ScriptBundle("~/plugins/fullCalendar").Include(
                      "~/Scripts/plugins/fullcalendar/moment.min.js",
                      "~/Scripts/plugins/fullcalendar/fullcalendar.min.js",
                      "~/Scripts/plugins/fullcalendar/locale/es.js"));



            // jsTree styles
            bundles.Add(new StyleBundle("~/plugins/jsTreeStyles").Include(
                "~/Content/plugins/jsTree/style.min.css"));

            // jsTree
            bundles.Add(new ScriptBundle("~/plugins/jsTree").Include(
                      "~/Scripts/plugins/jsTree/jstree.min.js"));

            // sweetAlert
            bundles.Add(new ScriptBundle("~/plugins/sweetAlertStyles").Include(
                      "~/Scripts/plugins/sweetalert/jssweetAlerttree.min.js"));









            bundles.Add(new StyleBundle("~/Content/hc/main").Include(
                      "~/Content/paciente/Antecedente.css"));

            bundles.Add(new ScriptBundle("~/Scripts/hc/main").Include(
                      "~/Scripts/paciente/Antecedente.js"));

            // Typehead
            bundles.Add(new ScriptBundle("~/plugins/typehead").Include(
                      "~/Scripts/plugins/typehead/bootstrap3-typeahead.min.js"));

            // Chartist
            bundles.Add(new StyleBundle("~/plugins/chartistStyles").Include(
                      "~/Content/plugins/chartist/chartist.min.css"));

            // Chartist
            bundles.Add(new ScriptBundle("~/plugins/chartist").Include(
                      "~/Scripts/plugins/chartist/chartist.min.js"));

            // c3 Styless
            bundles.Add(new StyleBundle("~/plugins/c3Styles").Include(
                      "~/Content/plugins/c3/c3.min.css"));

            // c3 Charts
            bundles.Add(new ScriptBundle("~/plugins/c3").Include(
                      "~/Scripts/plugins/c3/c3.min.js"));

            // D3
            bundles.Add(new ScriptBundle("~/plugins/d3").Include(
                      "~/Scripts/plugins/d3/d3.min.js"));

            // jasnyBootstrap styles
            bundles.Add(new StyleBundle("~/plugins/jasnyBootstrapStyles").Include(
                      "~/Content/plugins/jasny/jasny-bootstrap.min.css"));

            // jasnyBootstrap 
            bundles.Add(new ScriptBundle("~/plugins/jasnyBootstrap").Include(
                      "~/Scripts/plugins/jasny/jasny-bootstrap.min.js"));

            // Footable Styless
            bundles.Add(new StyleBundle("~/plugins/footableStyles").Include(
                      "~/Content/plugins/footable/footable.core.css"));

            // Footable alert
            bundles.Add(new ScriptBundle("~/plugins/footable").Include(
                      "~/Scripts/plugins/footable/footable.all.min.js"));

            // Morriss chart css styles
            bundles.Add(new StyleBundle("~/plugins/morrisStyles").Include(
                      "~/Content/plugins/morris/morris-0.4.3.min.css"));

            // Morriss chart
            bundles.Add(new ScriptBundle("~/plugins/morris").Include(
                      "~/Scripts/plugins/morris/raphael-2.1.0.min.js",
                      "~/Scripts/plugins/morris/morris.js"));

            // Masonry
            bundles.Add(new ScriptBundle("~/plugins/masonry").Include(
                      "~/Scripts/plugins/masonary/masonry.pkgd.min.js"));

            // Touch Spin Styless
            bundles.Add(new StyleBundle("~/plugins/touchSpinStyles").Include(
                      "~/Content/plugins/touchspin/jquery.bootstrap-touchspin.min.css"));

            // Touch Spin
            bundles.Add(new ScriptBundle("~/plugins/touchSpin").Include(
                      "~/Scripts/plugins/touchspin/jquery.bootstrap-touchspin.min.js"));

            // chosen styles
            bundles.Add(new StyleBundle("~/Content/plugins/chosen/chosenStyles").Include(
                      "~/Content/plugins/chosen/bootstrap-chosen.css"));

            // chosen 
            bundles.Add(new ScriptBundle("~/plugins/chosen").Include(
                      "~/Scripts/plugins/chosen/chosen.jquery.js"));

            // Date range picker Styless
            bundles.Add(new StyleBundle("~/plugins/dateRangeStyles").Include(
                      "~/Content/plugins/daterangepicker/daterangepicker-bs3.css"));

            // Date range picker
            bundles.Add(new ScriptBundle("~/plugins/dateRange").Include(
                      // Date range use moment.js same as full calendar plugin 
                      "~/Scripts/plugins/fullcalendar/moment.min.js",
                      "~/Scripts/plugins/daterangepicker/daterangepicker.js"));

            // Awesome bootstrap checkbox
            bundles.Add(new StyleBundle("~/plugins/awesomeCheckboxStyles").Include(
                      "~/Content/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"));

            // wizardSteps styles
            bundles.Add(new StyleBundle("~/plugins/wizardStepsStyles").Include(
                      "~/Content/plugins/steps/jquery.steps.css"));

            // wizardSteps 
            bundles.Add(new ScriptBundle("~/plugins/wizardSteps").Include(
                      "~/Scripts/plugins/steps/jquery.steps.min.js"));

            // Select2 Styless
            bundles.Add(new StyleBundle("~/plugins/select2Styles").Include(
                      "~/Content/plugins/select2/select2.min.css"));

            // Select2
            bundles.Add(new ScriptBundle("~/plugins/select2").Include(
                      "~/Scripts/plugins/select2/select2.full.min.js"));

            bundles.Add(new ScriptBundle("~/script/script").Include(
                      "~/Scripts/script.js"));

            bundles.Add(new StyleBundle("~/style/main").Include(
                      "~/Content/main.css",
                      "~/Content/plugins/recognition/recognition.css"));

            bundles.Add(new ScriptBundle("~/script/main").Include(
                      "~/Scripts/main.js",
                      "~/Scripts/plugins/recognition/recognition.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
