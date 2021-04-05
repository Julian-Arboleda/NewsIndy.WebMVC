using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Data
{
    public enum Direction { North, East, West, South, [Display(Name="North-East")] NorthEast, [Display(Name = "North-West")] NorthWest, [Display(Name = "South-East")] SouthEast, [Display(Name = "South-West")] SouthWest }
    public class Borough
    {
        [Key]
        public int BoroughId { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid CreatorId { get; set; }
        [Required]
        public Direction Direction { get; set; }
    }
}
