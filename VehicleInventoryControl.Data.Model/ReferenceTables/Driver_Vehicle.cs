using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.Data.Model.Models;

namespace VehicleInventoryControl.Data.Model.ReferenceTables
{
    public class Driver_Vehicle
    {
        [Key]
        public int Driver_VehicleId { get; set; }
        public string DriverId { get; set; }
        public virtual ApplicationUser Driver { get; set; }
        public int VehicleId { get; set; }
        public virtual Automobile Vehicle { get; set; }
    }
}
