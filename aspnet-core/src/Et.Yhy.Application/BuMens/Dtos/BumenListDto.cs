

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using Et.Yhy.BuMens;
using Et.Yhy.Complay;

namespace Et.Yhy.BuMens.Dtos
{
    public class BumenListDto : FullAuditedEntityDto 
    {

        
		/// <summary>
		/// Name
		/// </summary>
		[Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// IsTopBm
		/// </summary>
		[Required(ErrorMessage="IsTopBm不能为空")]
		public bool IsTopBm { get; set; }



		/// <summary>
		/// CompalysId
		/// </summary>
		public int CompalysId { get; set; }



		/// <summary>
		/// Compalys
		/// </summary>
		public Complays Compalys { get; set; }




    }
}