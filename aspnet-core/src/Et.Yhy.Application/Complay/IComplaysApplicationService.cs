
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
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using Et.Yhy.Complay.Dtos;
using Et.Yhy.Complay;

namespace Et.Yhy.Complay
{
    /// <summary>
    /// Complays应用层服务的接口方法
    ///</summary>
    public interface IComplaysAppService : IApplicationService
    {
        /// <summary>
		/// 获取Complays的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ComplaysListDto>> GetPaged(GetComplayssInput input);
         Task<ListResultDto<ComplaysListDto>> GetAll();

        

		/// <summary>
		/// 通过指定id获取ComplaysListDto信息
		/// </summary>
		Task<ComplaysListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetComplaysForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改Complays的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateComplaysInput input);


        /// <summary>
        /// 删除Complays信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除Complays
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出Complays为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
