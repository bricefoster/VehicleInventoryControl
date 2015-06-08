using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    public class VehicleCascadeVM
    {
        // This is for the driver
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<DriverHomeVM> VehicleDriverCascade { get; set; }
    }
}