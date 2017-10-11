using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SBP.Domain.SharedKernel.Filter
{
    public class ClaimsAuthorize : AuthorizeAttribute
    {
        public string Roles { get; set; }
        public string LocationID { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            ClaimsIdentity claimsIdentity;
            var httpContext = Thread.CurrentPrincipal;
            if (!(httpContext.Identity is ClaimsIdentity))
            {
                return false;
            }

            claimsIdentity = httpContext.Identity as ClaimsIdentity;
            var subIdClaims = claimsIdentity.FindFirst("Roles");
            var locIdClaims = claimsIdentity.FindFirst("LocationId");
            if (subIdClaims == null || locIdClaims == null)
            {
                // just extra defense
                return false;
            }

            var userSubId = subIdClaims.Value;
            var userLocId = subIdClaims.Value;

            // use your desired logic on 'userSubId' and `userLocId', maybe Contains if I get your example right?
            if (!this.Roles.Contains(userSubId) || !this.LocationID.Contains(userLocId))
            {
                return false;
            }

            //Continue with the regular Authorize check
            return base.IsAuthorized(actionContext);
        }
    }
}
