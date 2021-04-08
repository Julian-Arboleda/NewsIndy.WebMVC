using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Models
{
    public class MessageEdit
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? ModifiedDateCreated { get; set; }
    }
}
