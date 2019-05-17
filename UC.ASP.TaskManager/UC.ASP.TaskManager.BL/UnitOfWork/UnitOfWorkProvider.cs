using System;
using Microsoft.AspNetCore.Http;
using UC.ASP.TaskManager.DAL;

namespace UC.ASP.TaskManager.BL.UnitOfWork
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        private readonly Func<AppDbContext> dbContextFactory;
        private IUnitOfWork currentUnitOfWork;

        public UnitOfWorkProvider(Func<AppDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public virtual IUnitOfWork Create()
        {
            var uow = new UnitOfWork(dbContextFactory);
            uow.Disposing += OnUnitOfWorkDisposing;
            currentUnitOfWork = uow;
            return uow;
        }

        public IUnitOfWork GetCurrent()
        {
            return currentUnitOfWork;
        }

        private void OnUnitOfWorkDisposing(object sender, EventArgs e)
        {
            currentUnitOfWork = null;
        }
    }
}