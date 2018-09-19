using Microsoft.AspNetCore.Antiforgery;
using Future.Controllers;

namespace Future.Web.Host.Controllers
{
    public class AntiForgeryController : FutureControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
