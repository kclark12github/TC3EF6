using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TC3EF6.Domain
{
    [NotMapped]
    public class Rule<T>
    {
        public Func<T, bool> Test { get; set; }
        public string Property { get; set; }
        public string Message { get; set; }
    }
}
