using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VehicleInventoryControl.AppCS.ViewModels;

namespace VehicleInventoryControl.AppCS.Driver
{
    // Note-Cbiroan, 3 January 2015: ModelState.IsValid may not account for all cases. We may need to implement a custom filter.
    // For drivers
    [Authorize(Roles = ("Driver, Admin"))]
    public class DriverController : ApiController
    {
        // Note-Cbiroan, 3 Jan 2015: The following async operations may throw exceptions at run time.
        DriverInterface _adapter; // Not final


        public DriverController()
        {
            _adapter = new DriverAdapter(); 
        }

        public DriverController(DriverAdapter adapter)
        {
            _adapter = adapter;
        }

        public IHttpActionResult GetCascade()
        {
            return Ok(_adapter.GetCascade(User.Identity.GetUserId()));
        }

        [ActionName("Search")]
        public IHttpActionResult Search(SearchDateTimeVM source)
        {
            if (ModelState.IsValid)
            {
                return Ok(_adapter.SearchResults(source));
            }
            return BadRequest();
        }

        // The great async experiment
        // Note-Cbiroan, 03 Jan 2015: The great async experiment is successful.
        public async Task<IHttpActionResult> Reserve(ReserveVM source) // we may need to pack the Id into a view model
        { 
            if(ModelState.IsValid)
            {
                string UserId = User.Identity.GetUserId();
                ReserveVM model = await _adapter.Reserve(source, UserId);
                if (model != null)
                {
                    return Ok(model); // No conflicts, successful reservation
                }
                    return Conflict(); // Conflicting reservation dates
            }
            return BadRequest();
        }

        public HttpResponseMessage Report(CheckInVM source)
        {
            if (ModelState.IsValid)
            {
                _adapter.Report(source);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage Remove(int Id)
        {
            if (ModelState.IsValid)
            {
                _adapter.Remove(Id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
