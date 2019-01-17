
using AutoMapper;
using Et.Yhy.Complay;
using Et.Yhy.Complay.Dtos;

namespace Et.Yhy.Complay.Mapper
{

	/// <summary>
    /// 配置Complays的AutoMapper
    /// </summary>
	internal static class ComplaysMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Complays,ComplaysListDto>();
            configuration.CreateMap <ComplaysListDto,Complays>();

            configuration.CreateMap <ComplaysEditDto,Complays>();
            configuration.CreateMap <Complays,ComplaysEditDto>();

        }
	}
}
