using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TC3EF6.Data;
using TC3EF6.Data.Services.SQL;
using TC3EF6.Domain;
using TC3EF6.Domain.Interfaces;

namespace TC3EF6.Data.Services
{
    public abstract class SqlRepository<T> : INPCBase, IRepository<T> where T : class, IDataEntity
    {
        //public SqlRepository(TCContext context = null, PopulateAncillaryData populateAncillaryData = null)
        public SqlRepository()
        {
            Context = null;
            InitContextStuff();
        }
        //public SqlRepository(TCContext context)
        //{
        //    Context = context;
        //    InitContextStuff();
        //}
        #region "Properties"
        #region "Locals"
        private TCContext mContext = null;
        private DbSet<T> mDbSet = null;
        private int mCount = 0;
        private string mFilter = string.Empty;
        private string mFilterLINQ = string.Empty;
        private string mFilterSQL = string.Empty;
        private IQueryable<T> mQuery = null;
        private string mSortOrder = string.Empty;
        private string mSortOrderLINQ = string.Empty;
        private string mSortOrderSQL = string.Empty;
        private string mSQL = string.Empty;
        private SQLUtilities utilities = new SQLUtilities();
        #endregion
        protected TCContext Context
        {
            get => mContext;
            private set { SetProperty(ref mContext, value); }
        }
        public int Count
        {
            get => mCount;
            internal set { SetProperty(ref mCount, value); }
        }
        protected DbSet<T> DbSet
        {
            get => mDbSet;
            private set { SetProperty(ref mDbSet, value); }
        }
        public string Filter
        {
            get => mFilter;
            set { SetProperty(ref mFilter, value); }
        }
        public string FilterLINQ
        {
            get => mFilterLINQ;
            set { SetProperty(ref mFilterLINQ, value); }
        }
        public string FilterSQL
        {
            get => mFilterSQL;
            set { SetProperty(ref mFilterSQL, value); }
        }
        public IQueryable<T> Query
        {
            get => mQuery;
            internal set { SetProperty(ref mQuery, value); }
        }
        public string SortOrder
        {
            get => mSortOrder;
            set { SetProperty(ref mSortOrder, value); }
        }
        public string SortOrderLINQ
        {
            get => mSortOrderLINQ;
            set { SetProperty(ref mSortOrderLINQ, value); }
        }
        public string SortOrderSQL
        {
            get => mSortOrderSQL;
            set { SetProperty(ref mSortOrderSQL, value); }
        }
        public string SQL
        {
            get => mSQL;
            set { SetProperty(ref mSQL, value); }
        }
        #endregion

        private void InitializeSQLProps()
        {
            SQL = string.Empty;
            Filter = string.Empty; FilterLINQ = string.Empty; FilterSQL = string.Empty;
            SortOrder = string.Empty; SortOrderLINQ = string.Empty; SortOrderSQL = string.Empty;
        }
        private void InitContextStuff()
        {
            //_context = context == null ? new TCContext() : context;
            if (mContext == null) mContext = new TCContext();
            DbSet = mContext.Set<T>();
        }
        private void UpdateSQLProps()
        {
            SQL = Query.ToString();
            FilterSQL = (string)utilities.ParseSQLSelect(SQL, SQLUtilities.SqlParts.WhereClause);
            SortOrderSQL = (string)utilities.ParseSQLSelect(SQL, SQLUtilities.SqlParts.OrderByClause);

            string temp = string.Empty;
            if (!string.IsNullOrEmpty(FilterLINQ)) temp = $"LINQ: {FilterLINQ}";
            if (!string.IsNullOrEmpty(FilterSQL))
            {
                if (!string.IsNullOrEmpty(temp)) temp += "\n";
                temp += $"SQL: {FilterSQL}";
            }
            Filter = temp;

            temp = string.Empty;
            if (!string.IsNullOrEmpty(SortOrderLINQ)) temp = $"LINQ: {SortOrderLINQ}";
            if (!string.IsNullOrEmpty(SortOrderSQL))
            {
                if (!string.IsNullOrEmpty(temp)) temp += "\n";
                temp += $"SQL: {SortOrderSQL}";
            }
            SortOrder = temp;
        }
        //private void TestSQLParsing()
        //{
        //    string SQL = Query.ToString();
        //    Debug.WriteLine($"SQL: {SQL}");
        //    Debug.WriteLine($"SQL WhereClause: {utilities.ParseSQLSelect(SQL, SQLUtilities.SqlParts.WhereClause)}");
        //    Debug.WriteLine($"SQL OrderBy: {utilities.ParseSQLSelect(SQL, SQLUtilities.SqlParts.OrderByClause)}");
        //}

        public void Add(T newEntity)
        {
            DbSet.Add(newEntity);
            mContext.SaveChanges();
        }
        public async void AddAsync(T newEntity)
        {
            DbSet.Add(newEntity);
            await mContext.SaveChangesAsync();
        }
        public void Remove(T entity)
        {
            DbSet.Remove(entity);
            mContext.SaveChanges();
        }
        public async void RemoveAsync(T entity)
        {
            DbSet.Remove(entity);
            await mContext.SaveChangesAsync();
        }

        public virtual IQueryable<T> GetAll()
        {
            InitializeSQLProps();
            Query = DbSet.AsNoTracking();
            Count = Query.Count();
            UpdateSQLProps();
            return Query;
        }
        public async virtual Task<IQueryable<T>> GetAllAsync()
        {
            InitializeSQLProps();
            Query = DbSet.AsNoTracking();
            Count = await Query.CountAsync();
            UpdateSQLProps();
            return Query;
        }
        public virtual IQueryable<T> GetAll(string WhereClause)
        {
            InitializeSQLProps(); FilterSQL = WhereClause;
            Query = DbSet.Where(WhereClause);
            Count = Query.Count();
            UpdateSQLProps();
            return Query;
        }
        public async virtual Task<IQueryable<T>> GetAllAsync(string WhereClause)
        {
            InitializeSQLProps(); FilterSQL = WhereClause;
            Query = DbSet.Where(WhereClause);
            Count = await Query.CountAsync();
            UpdateSQLProps();
            return Query;
        }
        public virtual IQueryable<T> GetAll(string WhereClause, string OrderByClause)
        {
            InitializeSQLProps(); FilterSQL = WhereClause; SortOrderSQL = OrderByClause;
            if (!string.IsNullOrEmpty(WhereClause))
                Query = DbSet.Where(WhereClause);
           else
                Query = DbSet.AsNoTracking();
            if (!string.IsNullOrEmpty(OrderByClause)) Query = Query.OrderBy(OrderByClause);
            Count = Query.Count();
            UpdateSQLProps();
            return Query;
        }
        public async virtual Task<IQueryable<T>> GetAllAsync(string WhereClause, string OrderByClause)
        {
            InitializeSQLProps(); FilterSQL = WhereClause; SortOrderSQL = OrderByClause;
            if (!string.IsNullOrEmpty(WhereClause))
                Query = DbSet.Where(WhereClause);
            else
                Query = DbSet.AsNoTracking();
            if (!string.IsNullOrEmpty(OrderByClause)) Query = Query.OrderBy(OrderByClause);
            Count = await Query.CountAsync();
            UpdateSQLProps();
            return Query;
        }
        public virtual IQueryable<T> OrderBy(IQueryable<T> query, string OrderByClause)
        {
            SortOrderLINQ = string.Empty; SortOrderSQL = OrderByClause;
            Query = query.OrderBy(OrderByClause);
            UpdateSQLProps();
            return Query;
        }
        public virtual IQueryable<T> OrderBy<TKey>(IQueryable<T> query, Expression<Func<T, TKey>> keySelector)
        {
            SortOrderLINQ = keySelector.ToString() + " (Ascending)"; SortOrderSQL = string.Empty;
            Query = query.OrderBy(keySelector);
            UpdateSQLProps();
            return Query;
        }
        public virtual IQueryable<T> OrderByDescending<TKey>(IQueryable<T> query, Expression<Func<T, TKey>> keySelector)
        {
            SortOrderLINQ = keySelector.ToString() + " (Descending)"; SortOrderSQL = string.Empty;
            Query = query.OrderByDescending(keySelector);
            UpdateSQLProps();
            return Query;
        }

        //public virtual async Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> WhereClause, Expression<Func<T, TKey>> OrderByClause, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    if (includeProperties != null) {
        //        Query = GetAllIncluding(includeProperties).Where(WhereClause);
        //    } else if (WhereClause != null) {
        //        Query = _dbSet.Where(WhereClause);
        //    } else {
        //        Query = _dbSet.AsNoTracking();
        //    }
        //    if (OrderByClause != null) Query = Query.OrderBy(OrderByClause);
        //    Count = await Query.CountAsync();
        //    return Query;
        //}
        public virtual T FindBy(Guid id)
        {
            InitializeSQLProps();
            Query = FindBy(e => e.ID == id);
            UpdateSQLProps();
            return Query.SingleOrDefault();
        }
        public virtual async Task<T> FindByAsync(Guid id)
        {
            InitializeSQLProps();
            Query = await FindByAsync(e => e.ID == id);
            UpdateSQLProps();
            return Query.SingleOrDefault();
        }
        //Sample Call:
        //var data = await _repos.FindByAsync(b => b.MediaFormat == "MM Paperback" && b.AlphaSort.StartsWith("DUNE:"), b => b.Location)
        //    .Select(s => new { s.OID, s.Title, s.Author, s.Location.Name, s.Location.PhysicalLocation })
        //    .ToListAsync();
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> WhereClause, params Expression<Func<T, object>>[] includeProperties)
        {
            InitializeSQLProps();
            if (WhereClause != null) FilterLINQ = WhereClause.ToString();
            if (includeProperties != null)
            {
                Query = GetAllIncluding(includeProperties).Where(WhereClause);
            }
            else if (WhereClause != null)
            {
                Query = DbSet.Where(WhereClause);
            }
            else
            {
                Query = DbSet.AsNoTracking();
            }
            Count = Query.Count();
            UpdateSQLProps();
            return Query;
        }
        public virtual async Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> WhereClause, params Expression<Func<T, object>>[] includeProperties)
        {
            InitializeSQLProps();
            if (WhereClause != null) FilterLINQ = WhereClause.ToString();
            if (includeProperties != null)
            {
                Query = GetAllIncluding(includeProperties).Where(WhereClause);
            }
            else if (WhereClause != null)
            {
                Query = DbSet.Where(WhereClause);
            }
            else
            {
                Query = DbSet.AsNoTracking();
            }
            Count = await Query.CountAsync();
            UpdateSQLProps();
            return Query;
        }
        //public async virtual Task<IQueryable<T>> FindByAsync(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    if (includeProperties != null) {
        //        Query = GetAllIncluding(includeProperties);
        //    } else {
        //        Query = _dbSet.AsNoTracking();
        //    }
        //    Count = await Query.CountAsync();
        //    return Query;
        //}
        //public async virtual Task<T> FindByKeyAsync(Guid id)
        //{
        //    //Notes:
        //    //  This repository is intended for disconnected use, so our context will be discarded with each atomic 
        //    //  operation. The DbSet.Find method would search the set for cached data before going to the database,
        //    //  but since we're operating on a disconnected basis, that cache would be empty. Note that the Find method 
        //    //  is on the DbSet itself, and not available with AsNoTracking(), so using it here would cause our data to be
        //    //  cached, even though (disconnected as we are) it would only be discarded when the context goes out of scope.
        //    //  The Find method does handle determining which key to be used in finding the data we're looking for, and that
        //    //  may be worth the performance hits (minor as they may be) of these other issues.
        //    //return _dbSet.Find(id);   

        //    //After defining IEntity to enforce our T types will always have an Id property (assumed to be the 
        //    //primary key as a best practice), we can now use .AsNoTracking to do our Find...
        //    //However, if not all our T types implement the IEntity interface, this solution won't work...
        //    Query = null;
        //    T entity = _dbSet.AsNoTracking().SingleOrDefault(e => e.ID == id);
        //    mCallback?.Invoke();
        //    Count = entity == null ? 0 : 1;
        //    return entity;

        //    //The BuildLambdaForFindByKey, as the name implies, builds a new lambda expression based on a <T>Id
        //    //naming convention rather than a hard-coded Id property...
        //    //Expression<Func<T, bool>> lambda = Utilities.BuildLambdaForFindByKey<T>(id);
        //    //return _dbSet.AsNoTracking().SingleOrDefault(lambda);
        //}
        private IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet;
            Query = includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
            UpdateSQLProps();
            return Query;
        }

        public async void InsertDisconnectedAsync(T entity)
        {
            DbSet.Add(entity);
            await mContext.SaveChangesAsync();
        }
        public async void UpdateDisconnectedAsync(T entity)
        {
            DbSet.Attach(entity);
            mContext.Entry(entity).State = EntityState.Modified;
            await mContext.SaveChangesAsync();
        }
        public async void DeleteDisconnectedAsync(Guid id)
        {
            var entity = await FindByAsync(id);
            DbSet.Remove(entity);
            await mContext.SaveChangesAsync();
        }
    }
}
