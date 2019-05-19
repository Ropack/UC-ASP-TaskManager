using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UC.ASP.TaskManager.BL.UnitOfWork;
using UC.ASP.TaskManager.DAL;
using UC.ASP.TaskManager.DAL.Entities;

namespace UC.ASP.TaskManager.BL.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>, new()
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;

        protected virtual AppDbContext Context
        {
            get
            {
                var context = unitOfWorkProvider.GetCurrent()?.Context;
                if (context == null)
                {
                    throw new InvalidOperationException(
                        "The Repository must be used inside a unit of work!");
                }

                return context;
            }
        }

        public RepositoryBase(IUnitOfWorkProvider unitOfWorkProvider)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
        }

        public virtual TEntity GetById(int id)
        {
            return Context.Set<TEntity>().FirstOrDefault(r => r.Id == id);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(int id)
        {
            // try to get entity from the context
            var entity = Context.Set<TEntity>().Local.SingleOrDefault(e => e.Id.Equals(id));

            // if entity is not found in the context, create fake entity and attach it
            if (entity == null)
            {
                entity = new TEntity { Id = id };
                Context.Set<TEntity>().Attach(entity);
            }

            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public IList<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IList<TEntity> GetByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities.ToList())
            {
                Insert(entity);
            }
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities.ToList())
            {
                Update(entity);
            }
        }

        public void Delete(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                Delete(id);
            }
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities.ToList())
            {
                Delete(entity);
            }
        }

        public int GetCount()
        {
            return Context.Set<TEntity>().Count();
        }
    }
}