using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    // Note-CBiroan, 31 Dec 2014: This is for the admin add vehicle view
    public class VehicleAddVM : VehicleSearchVM
    {
        public int Miles { get; set; }
    }
}