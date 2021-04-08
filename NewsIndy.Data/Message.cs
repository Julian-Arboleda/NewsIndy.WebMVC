using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Data
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Subject { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Message()
        {
            DateCreated = DateTimeOffset.UtcNow;
        }
       // public DateTimeOffset? ModifiedDateCreated { get; set; }
        public Guid CreatorId { get; set; }
    }
}
