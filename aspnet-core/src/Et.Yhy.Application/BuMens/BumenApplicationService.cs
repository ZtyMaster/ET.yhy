
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using Et.Yhy.BuMens;
using Et.Yhy.BuMens.Dtos;
using Et.Yhy.BuMens.DomainService;
using Et.Yhy.BuMens.Authorization;


namespace Et.Yhy.BuMens
{
    /// <summary>
    /// Bumen应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class BumenAppService : YhyAppServiceBase, IBumenAppService
    {
        private readonly IRepository<Bumen, int> _entityRepository;

        private readonly IBumenManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public BumenAppService(
        IRepository<Bumen, int> entityRepository
        ,IBumenManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取Bumen的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(BumenPermissions.Query)] 
        public async Task<PagedResultDto<BumenListDto>> GetPaged(GetBumensInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<BumenListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<BumenListDto>>();

			return new PagedResultDto<BumenListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取BumenListDto信息
		/// </summary>
		[AbpAuthorize(BumenPermissions.Query)] 
		public async Task<BumenListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<BumenListDto>();
		}

		/// <summary>
		/// 获取编辑 Bumen
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BumenPermissions.Create,BumenPermissions.Edit)]
		public async Task<GetBumenForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetBumenForEditOutput();
BumenEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<BumenEditDto>();

				//bumenEditDto = ObjectMapper.Map<List<bumenEditDto>>(entity);
			}
			else
			{
				editDto = new BumenEditDto();
			}

			output.Bumen = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Bumen的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BumenPermissions.Create,BumenPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateBumenInput input)
		{

			if (input.Bumen.Id.HasValue)
			{
				await Update(input.Bumen);
			}
			else
			{
				await Create(input.Bumen);
			}
		}


		/// <summary>
		/// 新增Bumen
		/// </summary>
		[AbpAuthorize(BumenPermissions.Create)]
		protected virtual async Task<BumenEditDto> Create(BumenEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Bumen>(input);
            var entity=input.MapTo<Bumen>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<BumenEditDto>();
		}

		/// <summary>
		/// 编辑Bumen
		/// </summary>
		[AbpAuthorize(BumenPermissions.Edit)]
		protected virtual async Task Update(BumenEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Bumen信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BumenPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Bumen的方法
		/// </summary>
		[AbpAuthorize(BumenPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出Bumen为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


