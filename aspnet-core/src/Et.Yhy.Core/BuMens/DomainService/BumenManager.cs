

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using Et.Yhy;
using Et.Yhy.BuMens;


namespace Et.Yhy.BuMens.DomainService
{
    /// <summary>
    /// Bumen领域层的业务管理
    ///</summary>
    public class BumenManager :YhyDomainServiceBase, IBumenManager
    {
		
		private readonly IRepository<Bumen,int> _repository;

		/// <summary>
		/// Bumen的构造方法
		///</summary>
		public BumenManager(
			IRepository<Bumen, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitBumen()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
