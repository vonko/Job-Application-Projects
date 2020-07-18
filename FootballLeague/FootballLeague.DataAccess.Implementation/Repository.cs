using FootballLeague.DataAccess.DbModels;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace FootballLeague.DataAccess.Implementation
{
    public class Repository<TObject> : IRepository<TObject>
        where TObject : DbModelBase
    {
        protected FootballLeagueDbContext context;
        private bool shareContext;

        public Repository()
        {
            this.context = new FootballLeagueDbContext();
        }

        public Repository(FootballLeagueDbContext context)
        {
            this.context = context;
            this.shareContext = true;
        }

        protected DbSet<TObject> DbSet
        {
            get
            {
                return this.context.Set<TObject>();
            }
        }

        public void Dispose()
        {
            if (this.shareContext && this.context != null)
            {
                context.Dispose();
            }
        }

        public virtual IQueryable<TObject> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return this.DbSet.Where(predicate).AsQueryable<TObject>();
        }

        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            IQueryable<TObject> resetSet = filter != null ? this.DbSet.Where(filter).AsQueryable() : this.DbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();

            return resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<TObject, bool>> predicate)
        {
            return this.DbSet.Count(predicate) > 0;
        }

        public virtual TObject Find(params object[] keys)
        {
            return this.DbSet.Find(keys);
        }

        public virtual TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            return this.DbSet.FirstOrDefault(predicate);
        }

        public virtual TObject Create(TObject TObject)
        {
            TObject newEntry = this.DbSet.Add(TObject);
            if (!this.shareContext)
            {
                this.context.SaveChanges();
            }

            return newEntry;
        }

        public virtual void CreateOrUpdate(TObject tObject)
        {
            this.DbSet.AddOrUpdate(tObject);
            if (!this.shareContext)
            {
                this.context.SaveChanges();
            }
        }

        public virtual int Count
        {
            get
            {
                return this.DbSet.Count();
            }
        }

        public virtual int Update(TObject TObject)
        {
            DbEntityEntry<TObject> entry = this.context.Entry(TObject);
            this.DbSet.Attach(TObject);
            entry.State = EntityState.Modified;

            if (!this.shareContext)
            {
                return this.context.SaveChanges();
            }

            return 0;
        }

        public virtual int Delete(TObject TObject)
        {
            this.DbSet.Remove(TObject);
            if (!this.shareContext)
            {
                return this.context.SaveChanges();
            }

            return 0;
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

        protected string EscapeSqlString(string originalString)
        {
            string escapedString = originalString.Replace("'", "''");

            return escapedString;
        }      
    }
}
