using FootballLeague.DataAccess.DbModels;
using LiveResults.DataAccess;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FootballLeague.DataAccess.Implementation
{
    public abstract class RepositoryBase<TObject> : IRepositoryBase<TObject>
        where TObject : DbModelBase
    {
        protected FootballLeagueDbContext context;
        protected bool shareContext;

        protected DbSet<TObject> DbSet
        {
            get
            {
                return this.context.Set<TObject>();
            }
        }

        public RepositoryBase(FootballLeagueDbContext context)
        {
            this.context = context;
            this.shareContext = true;
        }

        public TObject FindRough(params object[] keys)
        {
            return this.DbSet.Find(keys);
        }

        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            IQueryable<TObject> resetSet = filter != null ? this.DbSet.Where(filter).AsQueryable() : this.DbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();

            return resetSet.AsQueryable();
        }

        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return this.DbSet.Where(predicate).AsQueryable<TObject>();
        }

        public virtual int Delete(Expression<Func<TObject, bool>> predicate)
        {
            IQueryable<TObject> objects = this.Filter(predicate);
            foreach (TObject obj in objects)
            {
                this.DbSet.Remove(obj);
            }

            if (!this.shareContext)
            {
                return this.context.SaveChanges();
            }

            return 0;
        }

        public void Dispose()
        {
            if (this.shareContext && this.context != null)
            {
                context.Dispose();
            }
        }
    }
}
