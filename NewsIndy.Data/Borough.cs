﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Data
{
    public enum Direction { North, East, West, South, NorthEast, NorthWest, SouthEast, SouthWest }
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
