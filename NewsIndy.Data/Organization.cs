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
        public string Name { get; set; }
        public bool IsFoodBank { get; set; }

        [ForeignKey(nameof(Borough))]
        public int BoroughId { get; set; }
        public virtual Borough Borough { get; set; }
    }
}
