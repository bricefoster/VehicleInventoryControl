using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    // Note-Cbiroan, 31 Dec 2014: This is for the admin home page.
    public class VehicleInfoVM : VehicleSearchVM // Inquisition-Cbiroan, 31 Dec 2014: Make into struct instead of class?
    {
        public bool IsActive { get; set; }
    }
}