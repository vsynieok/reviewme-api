using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewMe.Data.Models
{
    public class EntitySet<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
