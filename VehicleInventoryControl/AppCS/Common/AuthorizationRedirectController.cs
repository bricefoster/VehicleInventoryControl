using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace VehicleInventoryControl.AppCS.Common
{
    [Authorize]
    public class AuthorizationRedirectController : ApiController
    {
        
        public IHttpActionResult Get()
        {
            if(User.IsInRole("Driver"))
            {
                return Ok(Generate("Driver"));
            }
            if (User.IsInRole("Admin"))
            {
                return Ok(Generate("Admin"));
            }
            return Ok(Generate(""));
        }

        // On the fly. There is a better way.
        private Redirect Generate(string Id)
        {
            Redirect Redirect = new Redirect();
            Random chance = new Random(); // Random number generator;
            if (Id == "Driver")
            {
                Redirect.RedirectId = chance.Next(1, 1001);
            }
            else if (Id == "Admin")
            {
                Redirect.RedirectId = chance.Next(9000, 10001);
            }
            else
            {
                Redirect.RedirectId = 0;
            }
            return Redirect;
        }
    }

    internal class Redirect
    {
        public int RedirectId { get; set; } 
    }
}
