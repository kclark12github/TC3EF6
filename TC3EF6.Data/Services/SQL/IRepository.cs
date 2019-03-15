using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TC3EF6.Data.Services
{
    public interface IRepository<T>
    {
        int Count { get; }
        string Filter { get; set; }
        IQueryable<T> Query { get; }
        string SortOrder { get; set; }

        void Add(T newEntity);
        void AddAsync(T newEntity);
        void Remove(T entity);
        void RemoveAsync(T entity);

        IQueryable<T> GetAll();
        Task<IQueryable<T>> GetAllAsync();
        IQueryable<T> GetAll(string WhereClause);
        Task<IQueryable<T>> GetAllAsync(string WhereClause);
        IQueryable<T> GetAll(string WhereClause, string OrderByClause);
        Task<IQueryable<T>> GetAllAsync(string WhereClause, string OrderByClause);

        T FindBy(Guid id);
        Task<T> FindByAsync(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> WhereClause, params Expression<Func<T, object>>[] includeProperties);
        Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> WhereClause, params Expression<Func<T, object>>[] includeProperties);
        //IQueryable<T> FindBy(Expression<Func<T, bool>> WhereClause, Expression<Func<T, TKey>> OrderByClause, params Expression<Func<T, object>>[] includeProperties);
        //Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> WhereClause, Expression<Func<T, TKey>> OrderByClause, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> OrderBy(IQueryable<T> query, string OrderByClause);
        IQueryable<T> OrderBy<TKey>(IQueryable<T> query, Expression<Func<T, TKey>> keySelector);
        IQueryable<T> OrderByDescending<TKey>(IQueryable<T> query, Expression<Func<T, TKey>> keySelector);
    }
}
