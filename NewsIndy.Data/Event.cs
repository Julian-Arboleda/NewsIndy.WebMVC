using System;
using System.Data.Annotations;

namespace NewsIndy.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description {get;set;}
        
    }
}
