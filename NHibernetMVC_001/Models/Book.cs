using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernetMVC_001.Models
{
    public class Book
    {
        public virtual int BookId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Author { get; set; }
        public virtual string Publishers { get; set; }
    }
}