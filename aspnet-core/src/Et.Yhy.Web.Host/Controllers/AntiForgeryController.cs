using Microsoft.AspNetCore.Antiforgery;
using Et.Yhy.Controllers;

namespace Et.Yhy.Web.Host.Controllers
{
    public class AntiForgeryController : YhyControllerBase
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
