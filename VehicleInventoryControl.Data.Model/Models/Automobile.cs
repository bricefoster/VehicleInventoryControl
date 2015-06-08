using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.Data.Model.Abstracts;

namespace VehicleInventoryControl.Data.Model.Models
{
    public class Automobile : AbstractVehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        public int TotalMiles { get; set; }
    }
}
