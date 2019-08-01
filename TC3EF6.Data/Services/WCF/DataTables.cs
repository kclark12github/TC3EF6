using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TC3EF6.Data.Services.WCF
{
    [DataContract]
    public class DataTables<T>
    {
        [DataMember]
        public int Draw { get; set; }
        [DataMember]
        public int RecordsTotal { get; set; }
        [DataMember]
        public int RecordsFiltered { get; set; }
        [DataMember]
        public List<T> Data { get; set; }
    }
}
