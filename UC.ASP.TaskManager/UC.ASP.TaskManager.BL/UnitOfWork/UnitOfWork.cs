using System;
using UC.ASP.TaskManager.DAL;

namespace UC.ASP.TaskManager.BL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public event EventHandler Disposing;
        private bool disposed;
        public AppDbContext Context { get; }

        public UnitOfWork(Func<AppDbContext> dbContextFactory)
        {
            Context = dbContextFactory();
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Disposing?.Invoke(this, EventArgs.Empty);
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}