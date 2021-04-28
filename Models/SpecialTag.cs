﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSuperShop.Models
{
    public class SpecialTag

    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tag Name")]
        public string ProductType { get; set; }
    }
}
