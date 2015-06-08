using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using VehicleInventoryControl.AppCS.Driver;
using VehicleInventoryControl.AppCS.ViewModels;

namespace VehicleInventoryControl.AppCS.SignalR.Hubs
{
    // Until the username can be properly unpacked, the hub should only be used to notify of changes, but not handle entry into the repository.
    [HubName("reservation")]
    //[Authorize(Roles = "Driver, Admin")]
    public class ReservationHub : Hub
    {
        public void Reserve(int Id)
        {
            Clients.All.notify(Id);
        }
    }
}