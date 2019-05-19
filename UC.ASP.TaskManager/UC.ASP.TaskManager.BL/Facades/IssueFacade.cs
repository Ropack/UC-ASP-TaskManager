using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UC.ASP.TaskManager.BL.DTOs;
using UC.ASP.TaskManager.BL.Queries;
using UC.ASP.TaskManager.BL.Repositories;
using UC.ASP.TaskManager.BL.UnitOfWork;
using UC.ASP.TaskManager.DAL.Entities;

namespace UC.ASP.TaskManager.BL.Facades
{
    public class IssueFacade : FacadeBase
    {
        private readonly Func<LastTenIssuesQuery> lastTenIssuesQuery;
        private readonly IRepository<Issue> repository;
        public IssueFacade(IUnitOfWorkProvider unitOfWorkProvider, Func<LastTenIssuesQuery> lastTenIssuesQuery, IRepository<Issue> repository) : base(unitOfWorkProvider)
        {
            this.lastTenIssuesQuery = lastTenIssuesQuery;
            this.repository = repository;
        }

        public void SaveIssue(IssueEntryDto issue)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var entity = Mapper.Map<Issue>(issue);
                entity.CreatedDate = DateTime.UtcNow;
                repository.Insert(entity);
                uow.Commit();
            }
        }

        public List<IssueDto> GetLastTenIssues()
        {
            using (UnitOfWorkProvider.Create())
            {
                return lastTenIssuesQuery().Execute().ToList();
            }
        }
        public int GetIssuesCount()
        {
            using (UnitOfWorkProvider.Create())
            {
                return repository.GetCount();
            }
        }
    }
}