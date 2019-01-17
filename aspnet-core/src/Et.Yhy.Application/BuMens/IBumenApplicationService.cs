
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


using Et.Yhy.BuMens.Dtos;
using Et.Yhy.BuMens;

namespace Et.Yhy.BuMens
{
    /// <summary>
    /// Bumen应用层服务的接口方法
    ///</summary>
    public interface IBumenAppService : IApplicationService
    {
        /// <summary>
		/// 获取Bumen的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<BumenListDto>> GetPaged(GetBumensInput input);


		/// <summary>
		/// 通过指定id获取BumenListDto信息
		/// </summary>
		Task<BumenListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetBumenForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改Bumen的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateBumenInput input);


        /// <summary>
        /// 删除Bumen信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除Bumen
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出Bumen为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
