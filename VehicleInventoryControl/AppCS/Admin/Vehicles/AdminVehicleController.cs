using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VehicleInventoryControl.AppCS.Admin.Vehicles;
using VehicleInventoryControl.AppCS.ViewModels;
using VehicleInventoryControl.Data;
using VehicleInventoryControl.Data.Model.Models;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace VehicleInventoryControl.AppCS.Admin.Vehicle
{

    [Authorize(Roles = "Admin")]
    public class AdminVehicleController : ApiController
    {

        AdminVehicleInterface _adapter;
        public AdminVehicleController()
        {
            _adapter = new AdminVehicleAdapter();
        }
        public AdminVehicleController(AdminVehicleInterface adapter)
        {
            {
                _adapter = adapter;
            }
        }
        public IHttpActionResult GetAllVehiclesAdmin()
        {
            return Ok(_adapter.GetAllVehiclesAdmin());
        }

        public IHttpActionResult GetVehicleDetail(int Id)
        {
            return Ok(_adapter.GetVehicleDetail(Id));
        }

        public async Task<HttpResponseMessage> AddVehicle(VehicleAddVM source)
        {
            if (ModelState.IsValid)
            {
                if (await _adapter.AddVehicle(source))
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new HttpResponseMessage(HttpStatusCode.Conflict); // Better code?
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Please complete all fields before submitting");
        }

        public async Task<IHttpActionResult> EditVehicle(VehicleDetailVM source)
        {
            if (ModelState.IsValid)
            {
                if (await _adapter.EditVehicleDetail(source))
                {
                    return Ok(source);
                }
                return Conflict();
            }
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Chaz's Error message goes here");
            return BadRequest();
        }

        public async Task<HttpResponseMessage> Remove(string LicPlate) // We may need to add a view model
        {
            if (ModelState.IsValid)
            {
                if (await _adapter.Remove(LicPlate))
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new HttpResponseMessage(HttpStatusCode.Conflict); // This could be the wrong code.
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Please complete the entire form");
        }

        public IHttpActionResult EditCheckInVM(CheckInVM checkin)
        {
            if (ModelState.IsValid)
            {
                return Ok(_adapter.EditCheckInVM(checkin));
            }
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Chaz's Error message goes here");
            return BadRequest();
        }
        public HttpResponseMessage RemoveCheckIn(int Id)
        {
            if (ModelState.IsValid)
            {
                _adapter.RemoveCheckIn(Id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Chaz's Error message goes here");
            return response;
        }
    }
}
