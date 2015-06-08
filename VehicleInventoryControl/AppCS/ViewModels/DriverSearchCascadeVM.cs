using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    public class DriverSearchCascadeVM
    {
        // Note-Cbiroan, 31 Dec 2014: For the admin driver search. It will display all drivers in the system
        public List<DriverSearchVM> DriverSearchCascade { get; set; }
    }
}