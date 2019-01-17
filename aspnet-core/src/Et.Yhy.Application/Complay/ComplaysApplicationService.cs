
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


using Et.Yhy.Complay;
using Et.Yhy.Complay.Dtos;
using Et.Yhy.Complay.DomainService;
using Et.Yhy.Complay.Authorization;


namespace Et.Yhy.Complay
{
    /// <summary>
    /// Complays应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ComplaysAppService : YhyAppServiceBase, IComplaysAppService
    {
        private readonly IRepository<Complays, int> _entityRepository;

        private readonly IComplaysManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ComplaysAppService(
        IRepository<Complays, int> entityRepository
        ,IComplaysManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取Complays的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(ComplaysPermissions.Query)] 
        public async Task<PagedResultDto<ComplaysListDto>> GetPaged(GetComplayssInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ComplaysListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ComplaysListDto>>();

			return new PagedResultDto<ComplaysListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取ComplaysListDto信息
		/// </summary>
		[AbpAuthorize(ComplaysPermissions.Query)] 
		public async Task<ComplaysListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ComplaysListDto>();
		}

		/// <summary>
		/// 获取编辑 Complays
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ComplaysPermissions.Create,ComplaysPermissions.Edit)]
		public async Task<GetComplaysForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetComplaysForEditOutput();
ComplaysEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ComplaysEditDto>();

				//complaysEditDto = ObjectMapper.Map<List<complaysEditDto>>(entity);
			}
			else
			{
				editDto = new ComplaysEditDto();
			}

			output.Complays = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Complays的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ComplaysPermissions.Create,ComplaysPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateComplaysInput input)
		{

			if (input.Complays.Id.HasValue)
			{
				await Update(input.Complays);
			}
			else
			{
				await Create(input.Complays);
			}
		}


		/// <summary>
		/// 新增Complays
		/// </summary>
		[AbpAuthorize(ComplaysPermissions.Create)]
		protected virtual async Task<ComplaysEditDto> Create(ComplaysEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Complays>(input);
            var entity=input.MapTo<Complays>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<ComplaysEditDto>();
		}

		/// <summary>
		/// 编辑Complays
		/// </summary>
		[AbpAuthorize(ComplaysPermissions.Edit)]
		protected virtual async Task Update(ComplaysEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Complays信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ComplaysPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Complays的方法
		/// </summary>
		[AbpAuthorize(ComplaysPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        public async Task<ListResultDto<ComplaysListDto>> GetAll()
        {
            var roles = await _entityRepository.GetAllListAsync();
            return new ListResultDto<ComplaysListDto>(ObjectMapper.Map<List<ComplaysListDto>>(roles));

            //var query = _entityRepository.GetAllListAsync();
            // TODO:根据传入的参数添加过滤条件

            //var roles = await _roleRepository.GetAllListAsync();
            //return new PagedResultDto<ComplaysListDto>(ObjectMapper.Map<List<ComplaysListDto>>(query));
            

            //var entityList = await query
            //        .OrderBy(input.Sorting).AsNoTracking()
            //        .PageBy(input)
            //        .ToListAsync();

         
            //var entityListDtos = query.MapTo<List<ComplaysListDto>>();
            //var count = entityListDtos.Count();
            //return new PagedResultDto<ComplaysListDto>(count, entityListDtos);
        }

       

        /// <summary>
        /// 导出Complays为excel表,等待开发。
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


