using People.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using People.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace People.Infrastructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PeopleContext context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(PeopleContext context)
        {
            this.context = context;
            DbSet = this.context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
    }
}
