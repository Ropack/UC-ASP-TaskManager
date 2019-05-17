using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using UC.ASP.TaskManager.BL.DTOs;
using UC.ASP.TaskManager.BL.UnitOfWork;

namespace UC.ASP.TaskManager.BL.Queries
{
    public class TestQuery : QueryBase<TestDto>
    {
        public TestQuery(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        protected override IQueryable<TestDto> GetQueryable()
        {
            return Context.Issues.ProjectTo<TestDto>();
        }
    }
}