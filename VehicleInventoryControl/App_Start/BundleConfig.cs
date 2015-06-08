using System.Web;
using System.Web.Optimization;

namespace VehicleInventoryControl
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalR").Include(
                        "~/Scripts/jquery.signalR-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

           bundles.Add(new ScriptBundle("~/bundles/Angular").Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/JS").Include(
                    "~/AppJS/Core/CoreAJAXFactory.js",
                    "~/AppJS/Core/CoreAJAXLogin.js",
                    "~/AppJS/Core/CoreAuthFactory.js",
                    "~/AppJS/Core/CoreRoutes.js",
                    "~/AppJS/Core/CoreModule.js",
                    "~/AppJS/Common/CommonCommunicationFactory.js",
                    "~/AppJS/Common/CommonDateFactory.js",
                    "~/AppJS/Common/CommonValidationFactory.js",
                    "~/AppJS/Common/CommonNavigationController.js",
                    "~/AppJS/Common/CommonModule.js",
                    "~/AppJS/ECP/ECPLoginController.js",
                    "~/AppJS/ECP/ECPModule.js",
                    "~/AppJS/Admin/Home/AdminHomeController.js",
                    "~/AppJS/Admin/Home/AdminHomeModule.js",
                    "~/AppJS/Admin/Registration/RegistrationController.js",
                    "~/AppJS/Admin/Registration/RegistrationModule.js",
                    "~/AppJS/Admin/SearchDrivers/AdminSearchDriversController.js",
                    "~/AppJS/Admin/SearchDrivers/AdminSearchDriversModule.js",
                    "~/AppJS/Admin/VehicleInfo/AdminVehicleInfoController.js",
                    "~/AppJS/Admin/VehicleInfo/AdminVehicleInfoModule.js",
                    "~/AppJS/Admin/VehicleUpdate/AdminVehicleUpdateController.js",
                    "~/AppJS/Admin/VehicleUpdate/AdminVehicleUpdateModule.js",
                    "~/AppJS/Driver/CheckIn/DriverCheckInController.js",
                    "~/AppJS/Driver/CheckIn/DriverCheckInModule.js",
                    "~/AppJS/Driver/Home/DriverHomeController.js",
                    "~/AppJS/Driver/Home/DriverHomeModule.js",
                    "~/AppJS/Driver/Search/DriverSearchController.js",
                    "~/AppJS/Driver/Search/DriverSearchModule.js",
                    "~/AppJS/Driver/Map/MapController.js",
                    "~/AppJS/Driver/Map/MapModule.js",
                    "~/AppJS/Umbrella/UmbrellaModule.js")); // Achtung, umbrella must always be last in the bundle. Also, it is good practice to load the module last for each view
                 
               


            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
