using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC3EF6.Domain
{
    [NotMapped]
    public class ValidationRuleMessage
    {
        public ValidationRuleMessage()
        {

        }
        public int Id { get; set; }
        public ValidationRuleMessage(string PropertyName, string Message)
        {
            this.PropertyName = PropertyName;
            this.Message = Message;
        }
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
