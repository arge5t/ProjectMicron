using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicron.Domain.Entity
{
    public class Comment
    {
        public int Id { get; set; }

        public string Owner { get; set; }

        public string Text { get; set; }

        public DateTime TimeStamp { get; set; }

      
    }
}