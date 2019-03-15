using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC3EF6.Domain.Interfaces
{
    public interface IEntity
    {
        Guid ID { get; set; }
        Byte[] RowID { get; set; }
        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        bool HasErrors { get; }
    }
}
