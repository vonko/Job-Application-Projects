using FootballLeague.DataAccess.DbModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FootballLeague.DataAccess
{
    public interface IRepository<TObject> : IDisposable 
        where TObject : DbModelBase
    {
        /// <summary>
        /// Gets all objects from database
        /// </summary>
        IQueryable<TObject> All();

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate">Specified a filter</param>
        IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate);

        /// <summary>
        /// Gets objects from database with filting and paging.
        /// </summary>
        /// <param name="filter">Specified a filter</param>
        /// <param name="total">Returns the total records count of the filter.</param>
        /// <param name="index">Specified the page index.</param>
        /// <param name="size">Specified the page size</param>
        IQueryable<TObject> Filter(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        /// Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate">Specified the filter expression</param>
        bool Contains(Expression<Func<TObject, bool>> predicate);

        /// <summary>
        /// Find object by keys.
        /// </summary>
        /// <param name="keys">Specified the search keys.</param>
        TObject Find(params object[] keys);

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate"></param>
        TObject Find(Expression<Func<TObject, bool>> predicate);

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        TObject Create(TObject t);

        // <summary>
        /// Create a new object to database or updates it.
        /// </summary>
        /// <param name="t">Specified a new object to create/update.</param>
        void CreateOrUpdate(TObject t);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>        
        int Delete(TObject t);

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"></param>
        int Delete(Expression<Func<TObject, bool>> predicate);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        int Update(TObject t);

        /// <summary>
        /// Get the total objects count.
        /// </summary>
        int Count { get; }
    }
}
