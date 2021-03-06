using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Beauty.Specs.Common.FakeDb
{
    /// <summary>
    /// Provides helper methods for the InMemoryDbSet.
    /// </summary>
    public class DbSetHelper
    {
        /// <summary>
        /// Increments the provided property as if it was an identity column in a database.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <typeparam name="TProperty">The type of the primary key property.</typeparam>
        /// <param name="primaryKey">A lambda expression which provides the primary key.</param>
        /// <param name="entity">The entity set to update.</param>
        public static int IncrementPrimaryKey<T>(Expression<Func<T, long>> primaryKey, IDbSet<T> entity) where T : class
        {
            int newKeys = 0;

            long maxId = entity.Any() ? entity.Max(e => primaryKey.Compile().Invoke(e)) + 1 : 0;
            foreach (T item in entity.Where(e => primaryKey.Compile().Invoke(e) <= 0))
            {
                PropertyInfo propertyInfo = null;
                if (primaryKey.Body is MemberExpression)
                {
                    propertyInfo = (primaryKey.Body as MemberExpression).Member as PropertyInfo;
                }
                else
                {
                    propertyInfo = (((UnaryExpression)primaryKey.Body).Operand as MemberExpression).Member as PropertyInfo;
                }

                if (propertyInfo.PropertyType == typeof(long))
                {
                    propertyInfo.SetValue(item, maxId, null);
                }
                else if (propertyInfo.PropertyType == typeof(int))
                {
                    propertyInfo.SetValue(item, (int)maxId, null);
                }

                newKeys++;

                maxId++;
            }

            return newKeys;
        }
    }
}
