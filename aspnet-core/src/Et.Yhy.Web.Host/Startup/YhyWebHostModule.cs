using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Et.Yhy.Configuration;

namespace Et.Yhy.Web.Host.Startup
{
    [DependsOn(
       typeof(YhyWebCoreModule))]
    public class YhyWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public YhyWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YhyWebHostModule).GetAssembly());
        }
    }
}
