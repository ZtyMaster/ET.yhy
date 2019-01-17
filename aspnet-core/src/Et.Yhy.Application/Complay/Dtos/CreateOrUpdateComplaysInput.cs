

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Et.Yhy.Complay;

namespace Et.Yhy.Complay.Dtos
{
    public class CreateOrUpdateComplaysInput
    {
        [Required]
        public ComplaysEditDto Complays { get; set; }

    }
}