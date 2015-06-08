using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.AppCS.ViewModels;

namespace VehicleInventoryControl.AppCS.Admin.Drivers
{
    interface AdminDriverInterface
    {
        DriverSearchCascadeVM GetCascade();
        bool Post(RegistrationVM source);
        bool Delete(string EmployeeNumber); // Note-Cbiroan, 31 Dec 2014: Soft delete
        RegistrationVM Edit(RegistrationVM source, string EmployeeNumber);
        RegistrationVM Get(string EmployeeNumber);
    }
}
