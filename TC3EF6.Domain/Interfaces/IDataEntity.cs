using System;

namespace TC3EF6.Domain.Interfaces
{
    public interface IDataEntity : IEntity
    {
        int? OID { get; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
