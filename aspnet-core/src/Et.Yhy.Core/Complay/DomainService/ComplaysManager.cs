

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
using Et.Yhy.Complay;


namespace Et.Yhy.Complay.DomainService
{
    /// <summary>
    /// Complays领域层的业务管理
    ///</summary>
    public class ComplaysManager :YhyDomainServiceBase, IComplaysManager
    {
		
		private readonly IRepository<Complays,int> _repository;

		/// <summary>
		/// Complays的构造方法
		///</summary>
		public ComplaysManager(
			IRepository<Complays, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitComplays()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
