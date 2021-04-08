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
    public class VolunteerListItem
    {
        public int VolunteerId { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName}";
            }

        }

        [Required]
        public int OrgId { get; set; }
    }
}
