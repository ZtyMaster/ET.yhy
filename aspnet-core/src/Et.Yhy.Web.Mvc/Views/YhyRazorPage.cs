using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Et.Yhy.Web.Views
{
    public abstract class YhyRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected YhyRazorPage()
        {
            LocalizationSourceName = YhyConsts.LocalizationSourceName;
        }
    }
}
