using NewsIndy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Models
{
    public class BoroughListItem
    {
        public int BoroughId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Side of Indy")]
        public Direction Direction { get; set; }
    }
}
