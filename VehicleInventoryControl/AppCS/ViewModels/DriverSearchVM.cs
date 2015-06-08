using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    // Note-Cbiroan, 31 Dec 2014: This is for the admin driver search
    public class DriverSearchVM
    {
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}