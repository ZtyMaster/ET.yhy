
using AutoMapper;
using Et.Yhy.BuMens;
using Et.Yhy.BuMens.Dtos;

namespace Et.Yhy.BuMens.Mapper
{

	/// <summary>
    /// 配置Bumen的AutoMapper
    /// </summary>
	internal static class BumenMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Bumen,BumenListDto>();
            configuration.CreateMap <BumenListDto,Bumen>();

            configuration.CreateMap <BumenEditDto,Bumen>();
            configuration.CreateMap <Bumen,BumenEditDto>();

        }
	}
}
