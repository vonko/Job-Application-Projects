using DevelopersSurvey.DataAccess.DbModels;
using DevelopersSurvey.DataAccess.Implementation.Context;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace DevelopersSurvey.DataAccess.Implementation
{
    public abstract class RepositoryBase<TObject> : IRepositoryBase<TObject>
        where TObject : DbModelBase
    {
        protected DevelopersSurveyDbContext context;
        protected bool shareContext;

        protected DbSet<TObject> DbSet
        {
            get
            {
                return this.context.Set<TObject>();
            }
        }

        public RepositoryBase()
        {
            this.context = new DevelopersSurveyDbContext();
            this.shareContext = true;
        }

        public virtual IQueryable<TObject> All()
        {
            return this.DbSet.AsQueryable();
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

        public virtual int Update(TObject obj)
        {
            DbEntityEntry<TObject> entry = this.context.Entry(obj);
            this.DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return this.context.SaveChanges();
        }

        public virtual int Delete(int id)
        {
            TObject obj = this.DbSet.Find(id);

            if (obj != null)
            {
                this.DbSet.Remove(obj);
            }

            return this.context.SaveChanges();
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
