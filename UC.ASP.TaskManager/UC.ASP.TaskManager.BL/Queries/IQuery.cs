using System;
using System.Collections.Generic;

namespace UC.ASP.TaskManager.BL.Queries
{
    public interface IQuery<TResult>
    {
        IList<TResult> Execute();
    }
}