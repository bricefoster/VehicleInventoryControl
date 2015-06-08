using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleInventoryControl.AppCS.ViewModels
{
    public class RegistrationVM : DriverSearchVM
    {
        // Note-Cbiroan, 31 Dec 2014: This is for the admin register drivers view
        [Required]
        public DateTime DLExpDate {get;set;} // Driver's license expiration date
        [Required]
        public DateTime InsExpDate { get; set; } // Insurance expiration date for the specific driver
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirm { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}