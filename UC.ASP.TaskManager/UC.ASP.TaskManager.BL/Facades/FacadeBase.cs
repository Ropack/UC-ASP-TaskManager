using System;
using UC.ASP.TaskManager.BL.UnitOfWork;

namespace UC.ASP.TaskManager.BL.Facades
{
    public class FacadeBase : IFacade
    {
        protected readonly IUnitOfWorkProvider UnitOfWorkProvider;
        public FacadeBase(IUnitOfWorkProvider unitOfWorkProvider)
        {
            UnitOfWorkProvider = unitOfWorkProvider;
        }
    }
}
