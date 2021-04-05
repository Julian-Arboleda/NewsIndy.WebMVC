using NewsIndy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Models
{
    public class VolunteerListitem
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName}";
            }

        }

        [ForeignKey(nameof(Organization))]
        [Required]
        public int OrgId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
