using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TC3EF6.Data;
using TC3EF6.Domain.Classes;
using TC3EF6.Domain.Interfaces;

namespace TC3EF6.Data.Services
{
    public class SqlImageRepository<T> : SqlRepository<T>, IImageRepository<T> where T : class, IImageEntity
    {
        internal DbSet<Image> Images;
        public SqlImageRepository() : base()
        {
            InitContextStuff();
        }
        //public SqlImageRepository(TCContext context = null) : base(context)
        //{
        //    InitContextStuff();
        //}
        private void InitContextStuff()
        {
            Images = Context.Set<Image>();
        }

        public virtual T FindByIDWithImages(Guid id)
        {
            T entity = base.FindBy(id);
            if (entity != null) entity.Images = GetImages(entity);
            return entity;
        }
        public async virtual Task<T> FindByIDWithImagesAsync(Guid id)
        {
            T entity = await base.FindByAsync(id);
            if (entity != null) entity.Images = await GetImagesAsync(entity);
            return entity;
        }
        public List<Image> GetImages(T entity)
        {
            string TableName = Context.TypeToTableName(entity.GetType().BaseType.Name);
            return Images.Where(s => s.TableName == TableName && s.RecordID == entity.ID).ToList();
        }
        public async Task<List<Image>> GetImagesAsync(T entity)
        {
            string TableName = Context.TypeToTableName(entity.GetType().BaseType.Name);
            return await Images.Where(s => s.TableName == TableName && s.RecordID == entity.ID).ToListAsync();
        }
    }
}
