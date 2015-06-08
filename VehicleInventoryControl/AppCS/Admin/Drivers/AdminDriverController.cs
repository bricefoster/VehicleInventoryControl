using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Security;
using VehicleInventoryControl.AppCS.Admin.Drivers;
using VehicleInventoryControl.AppCS.ViewModels;
using VehicleInventoryControl.Data;

namespace VehicleInventoryControl.AppCS.Admin.Driver
{
    [Authorize(Roles = "Admin")]
    public class AdminDriverController : ApiController
    {
        AdminDriverInterface _adapter;
        public AdminDriverController()
        {

            _adapter = new AdminDriverAdapter();
        }

        public AdminDriverController(AdminDriverInterface adapter)
        {
            _adapter = adapter;
        }

        public IHttpActionResult GetCascade()
        {
            return Ok(_adapter.GetCascade());
        }
        public IHttpActionResult Post(RegistrationVM source)
        {
            if (ModelState.IsValid)
            {
                return Ok(_adapter.Post(source));

            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Chaz's Error message goes here");
            return BadRequest();
        }
        public IHttpActionResult Remove(RegistrationVM source)
        {
            if (ModelState.IsValid)
            {
                string EmployeeNumber = source.EmployeeNumber;
                return Ok(_adapter.Delete(EmployeeNumber));
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Chaz's Error message goes here");
            return BadRequest();
        }
        public IHttpActionResult Edit(RegistrationVM source)
        {
            if (ModelState.IsValid)
            {
                return Ok(_adapter.Edit(source));
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Chaz's Error message goes here");
            return BadRequest();
        }
        public IHttpActionResult GetDriver(string Id)
        {
            if (ModelState.IsValid)
            {
                return Ok(_adapter.Get(Id));

            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Chaz's Error message goes here");
            return BadRequest();
        }
    }
}
