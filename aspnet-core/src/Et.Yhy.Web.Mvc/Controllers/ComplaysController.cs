using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Et.Yhy.Authorization;
using Et.Yhy.Complay;
using Et.Yhy.Complay.Dtos;
using Et.Yhy.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Et.Yhy.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Complays)]
    public class ComplaysController : YhyControllerBase
    {
        private readonly IComplaysAppService  _AppService;

        public ComplaysController(IComplaysAppService AppService)
        {
            _AppService = AppService;
        }
        public async Task<IActionResult> Index(GetComplayssInput ipt)
        {
           
            var dtos=await _AppService.GetPaged(ipt);
            return View(dtos);
        }
    }
}