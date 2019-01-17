using Abp.AspNetCore.Mvc.ViewComponents;

namespace Et.Yhy.Web.Views
{
    public abstract class YhyViewComponent : AbpViewComponent
    {
        protected YhyViewComponent()
        {
            LocalizationSourceName = YhyConsts.LocalizationSourceName;
        }
    }
}
