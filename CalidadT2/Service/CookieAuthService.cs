using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace CalidadT2.Service
{
    public interface ICookieAuthService
    {
        void SetHttpContext(HttpContext httpContext);
        public void Login(ClaimsPrincipal claim);

        public Claim ObetenerClaim();
    }


    public class CookieAuthService : ICookieAuthService
    {
        private HttpContext httpContext;

        public void SetHttpContext(HttpContext httpContext)
        {
            this.httpContext = httpContext;
        }

        public void Login(ClaimsPrincipal claim)
        {
            httpContext.SignInAsync(claim);
            
        }

        public Claim ObetenerClaim()
        {
            var claim = httpContext.User.Claims.FirstOrDefault();
            return claim;
        }
    }
}