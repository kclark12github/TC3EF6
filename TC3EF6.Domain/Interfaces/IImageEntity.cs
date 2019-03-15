using System.Collections.Generic;
using TC3EF6.Domain.Classes;

namespace TC3EF6.Domain.Interfaces
{
    public interface IImageEntity : IDataEntity
    {
        List<Image> Images { get; set; }
    }
}
