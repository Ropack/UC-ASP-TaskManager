using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UC.ASP.TaskManager.BL.DTOs;
using UC.ASP.TaskManager.BL.Facades;

namespace UC.ASP.TaskManager.BO.Controllers
{
    public class IssuesController : Controller
    {
        private readonly TestFacade facade;
        public IssuesController(TestFacade facade)
        {
            this.facade = facade;
        }
        public IEnumerable<TestDto> Privacy()
        {
            return facade.TestMethod();
        }
    }
}