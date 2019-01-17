

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Et.Yhy.BuMens;

namespace Et.Yhy.BuMens.Dtos
{
    public class CreateOrUpdateBumenInput
    {
        [Required]
        public BumenEditDto Bumen { get; set; }

    }
}