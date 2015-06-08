using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    public class VehicleDateTimeSearchVM : VehicleSearchVM
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; } 
    }
}