using System;
using System.Linq.Expressions;

namespace TC3EF6.Data.CustomMigrationOperations
{
    public static class Utilities
    {
        public static Expression<Func<TEntity, bool>> BuildLambdaForFindByKey<TEntity>(int id)
        {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, typeof(TEntity).Name + "Id");
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }
        public static string GetSchema(string name)
        {
            if (name.Contains("."))
            {
                string[] composite = name.Split(new char[] { '.' });
                if (composite.Length == 2)  //Expect dbo.table format...
                {
                    return composite[0];
                }
            }
            return "dbo";
        }
        public static string GetTableName(string name)
        {
            if (name.Contains("."))
            {
                string[] composite = name.Split(new char[] { '.' });
                if (composite.Length == 2)  //Expect dbo.table format...
                {
                    return composite[1];
                }
            }
            return name;
        }
    }
}