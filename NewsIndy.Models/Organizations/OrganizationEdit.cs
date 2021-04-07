﻿using NewsIndy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Models
{
    public class OrganizationEdit
    {
        public int OrgId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("BoroughId")]
        [Display(Name = "Borough")]
        public int BoroughId { get; set; }
        public virtual Borough Borough { get; set; }
    }
}
