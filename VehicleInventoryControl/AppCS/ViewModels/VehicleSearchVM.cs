using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    // Note-Cbiroan, 31 Dec 2014: This is for the driver's search
    public class VehicleSearchVM
    {
        public string LicPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int VehicleId { get; set; }
        public int TotalMiles { get; set; }
        public bool IsReserved { get; set; } // isActive?
    }
}
