using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    public class VehicleDetailVM
    {
        public int VehicleId { get; set; }
        public int Year { get; set; }
        public int TotalMiles { get; set; }
        public int TotalMilesForMonth { get; set; }
        public string LicPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        //public string CurrentlyUsedBy { get; set; }

    }
}