using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TC3EF6.Domain.Classes;
using TC3EF6.Domain.Classes.Stash;

namespace TC3EF6.Data.Services
{
    public interface IImageRepository<T> : IRepository<T>
    {
        T FindByIDWithImages(Guid id);
        Task<T> FindByIDWithImagesAsync(Guid id);
        List<Image> GetImages(T entity);
        Task<List<Image>> GetImagesAsync(T entity);
    }
}
