using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryControl.AppCS.ViewModels;

namespace VehicleInventoryControl.AppCS.Admin.Drivers
{
    public interface AdminDriverInterface
    {
        DriverSearchCascadeVM GetCascade();
        Task<bool> Post(RegistrationVM source);
        bool Delete(string EmployeeNumber); // Note-Cbiroan, 31 Dec 2014: Soft delete
        RegistrationVM Edit(RegistrationVM source);
        RegistrationVM Get(string EmployeeNumber);
    }
}
