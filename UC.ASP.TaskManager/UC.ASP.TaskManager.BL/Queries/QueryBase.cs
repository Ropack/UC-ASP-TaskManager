using System;
using System.Collections.Generic;
using System.Linq;
using UC.ASP.TaskManager.BL.UnitOfWork;
using UC.ASP.TaskManager.DAL;

namespace UC.ASP.TaskManager.BL.Queries
{
    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        protected virtual AppDbContext Context
        {
            get
            {
                var context = UnitOfWorkProvider.GetCurrent()?.Context;
                if (context == null)
                {
                    throw new InvalidOperationException("The Query must be used inside a unit of work!");
                }
                return context;
            }
        }
        protected readonly IUnitOfWorkProvider UnitOfWorkProvider;

        protected QueryBase(IUnitOfWorkProvider unitOfWorkProvider)
        {
            UnitOfWorkProvider = unitOfWorkProvider;
        }
        public IList<TResult> Execute()
        {
            return GetQueryable().ToList();
        }
        protected abstract IQueryable<TResult> GetQueryable();
    }
}