using System.Linq;
using AutoMapper.QueryableExtensions;
using UC.ASP.TaskManager.BL.DTOs;
using UC.ASP.TaskManager.BL.UnitOfWork;

namespace UC.ASP.TaskManager.BL.Queries
{
    public class LastTenIssuesQuery : QueryBase<IssueDto>
    {
        public LastTenIssuesQuery(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        protected override IQueryable<IssueDto> GetQueryable()
        {
            return Context.Issues.OrderBy(i => i.CreatedDate).Take(10).ProjectTo<IssueDto>();
        }
    }
}