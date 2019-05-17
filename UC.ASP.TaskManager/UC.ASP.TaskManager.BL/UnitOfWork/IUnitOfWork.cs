using System;
using UC.ASP.TaskManager.DAL;

namespace UC.ASP.TaskManager.BL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        AppDbContext Context { get; }
        void Commit();
    }
}