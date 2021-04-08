using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewsIndy.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description {get;set;}
        [ForeignKey("BoroughId")]       
        public int BoroughId { get; set; }
        public virtual Borough Borough {get;set;}
    }
}
