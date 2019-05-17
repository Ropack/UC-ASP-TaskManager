using System;

namespace UC.ASP.TaskManager.BL.UnitOfWork
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork Create();
        IUnitOfWork GetCurrent();
    }
}