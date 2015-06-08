using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    // Note-Cbiroan, 31 Dec 2014: This is for the admin home page. It will display (or cascade) a list of vehicles
    public class VehicleAdminCascadeVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<VehicleInfoVM> VehicleAdminInfoCascade { get; set; }
        public List<DriverHomeVM> VehicleAdminInfoReservedCascade { get; set; }
        public List<VehicleInfoVM> VehicleInventory { get; set; }
    }
}