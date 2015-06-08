using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    public class VehicleDetailCascadeVM : VehicleDetailVM
    {
        public List<CheckInVM> CheckInCascade { get; set; }
    }
}