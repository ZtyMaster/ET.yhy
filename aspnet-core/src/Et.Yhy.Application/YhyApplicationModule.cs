using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Et.Yhy.Authorization;
using Et.Yhy.BuMens.Authorization;
using Et.Yhy.BuMens.Mapper;
using Et.Yhy.Complay.Authorization;
using Et.Yhy.Complay.Mapper;

namespace Et.Yhy
{
    [DependsOn(
        typeof(YhyCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class YhyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {

            Configuration.Authorization.Providers.Add<YhyAuthorizationProvider>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // ....

                // 只需要复制这一段
                ComplaysMapper.CreateMappings(configuration);
                BumenMapper.CreateMappings(configuration);

                // ....
            });

            Configuration.Authorization.Providers.Add<ComplaysAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<BumenAuthorizationProvider>();



        }

        public override void Initialize()
        {
            var thisAssembly = typeof(YhyApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
