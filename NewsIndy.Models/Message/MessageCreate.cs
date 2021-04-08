using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Models
{
    public class MessageCreate
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public string Subject { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? ModifiedDateCreated { get; set; }

    }
}
