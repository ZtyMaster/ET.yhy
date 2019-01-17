

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using Et.Yhy.Complay;
using System.Collections.Generic;
using Et.Yhy.Authorization.Users;
using Et.Yhy.BuMens;

namespace Et.Yhy.Complay.Dtos
{
    public class ComplaysListDto : FullAuditedEntityDto 
    {

        
		/// <summary>
		/// NameTXT
		/// </summary>
		[Required(ErrorMessage="NameTXT不能为空")]
		public string NameTXT { get; set; }



		/// <summary>
		/// OverTime
		/// </summary>
		public DateTime OverTime { get; set; }



		/// <summary>
		/// Bumens
		/// </summary>
		public List<Bumen> Bumens { get; set; }



		/// <summary>
		/// Users
		/// </summary>
		public List<User> Users { get; set; }



		/// <summary>
		/// MaxPersons
		/// </summary>
		public int MaxPersons { get; set; }




    }
}