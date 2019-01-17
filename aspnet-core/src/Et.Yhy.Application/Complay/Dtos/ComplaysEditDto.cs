
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using Et.Yhy.Authorization.Users;
using Et.Yhy.BuMens;
using Et.Yhy.Complay;

namespace  Et.Yhy.Complay.Dtos
{
    public class ComplaysEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
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