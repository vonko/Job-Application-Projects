using FootballLeague.DataAccess.DbModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LiveResults.DataAccess
{
    public interface IRepositoryBase<TObject> : IDisposable
        where TObject : DbModelBase
    {
        TObject FindRough(params object[] keys);

        IQueryable<TObject> Filter(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50);

        IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate);

        int Delete(Expression<Func<TObject, bool>> predicate);

        void Dispose();
    }
}
