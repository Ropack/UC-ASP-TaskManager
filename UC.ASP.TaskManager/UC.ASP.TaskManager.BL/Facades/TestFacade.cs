using System;
using System.Collections.Generic;
using UC.ASP.TaskManager.BL.DTOs;
using UC.ASP.TaskManager.BL.Queries;
using UC.ASP.TaskManager.BL.UnitOfWork;

namespace UC.ASP.TaskManager.BL.Facades
{
    public class TestFacade : FacadeBase
    {
        private readonly Func<TestQuery> query;
        public TestFacade(IUnitOfWorkProvider unitOfWorkProvider, Func<TestQuery> query) : base(unitOfWorkProvider)
        {
            this.query = query;
        }

        public IList<TestDto> TestMethod()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return query().Execute();
            }
        }
    }
}