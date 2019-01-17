using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Et.Yhy.Controllers;

namespace Et.Yhy.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : YhyControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
