using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Data
{
   public class Organization
    {
        [Key]
        public int OrgId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsFoodBank { get; set; }
        [Required]
        public bool IsShelter { get; set; }

        public int BoroughId { get; set; }
        [ForeignKey("BoroughId")]
        public virtual Borough Borough { get; set; }
    }
}
