using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC3EF6.Domain
{
    public class ValidationRuleMessages : List<ValidationRuleMessage>
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ValidationRuleMessage item in this)
                sb.Append(item.Message + Environment.NewLine);
            return sb.ToString();
        }
    }
}
