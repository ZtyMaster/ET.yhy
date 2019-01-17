using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;
using Et.Yhy.Complay;

namespace Et.Yhy.BuMens
{
    public class Bumen:FullAuditedEntity
    {
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 是否顶级部门
        /// </summary>
        public bool IsTopBm { get; set; }
        /// <summary>
        /// 上级部门
        /// </summary>       
        public int CompalysId { get; set; }
        public Complays Compalys { get; set; }
       
        
    }
}
