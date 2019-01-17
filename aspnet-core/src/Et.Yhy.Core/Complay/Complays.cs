using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;
using Et.Yhy.Authorization.Users;
using Et.Yhy.BuMens;

namespace Et.Yhy.Complay
{
    public class Complays:FullAuditedEntity
    {
        [Required]
        public string NameTXT { get; set; }
        public DateTime OverTime { get; set; }
        public int MaxPersons { get; set; }
        public ICollection<Bumen> Bumens { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
