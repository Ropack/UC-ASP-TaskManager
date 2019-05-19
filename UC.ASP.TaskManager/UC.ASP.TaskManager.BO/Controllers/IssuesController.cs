using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using UC.ASP.TaskManager.BL.DTOs;
using UC.ASP.TaskManager.BL.Facades;
using UC.ASP.TaskManager.BO.Hubs;

namespace UC.ASP.TaskManager.BO.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IssueFacade facade;
        private readonly IHubContext<IssuesHub> hubContext;
        public IssuesController(IssueFacade facade, IHubContext<IssuesHub> hubContext)
        {
            this.facade = facade;
            this.hubContext = hubContext;
        }
        [HttpPost]
        public async Task<IActionResult> SubmitIssue([FromBody]IssueEntryDto issue)
        {
            facade.SaveIssue(issue);
            var list = facade.GetLastTenIssues();
            JsonSerializerSettings dateFormatSettings = new JsonSerializerSettings
            {
                DateFormatString = "dd.MM.yyyy HH:mm:ss"
            };
            var json = JsonConvert.SerializeObject(list, dateFormatSettings);
            var count = facade.GetIssuesCount();
            await hubContext.Clients.All.SendAsync("UpdateIssues", count, json);
            return Ok();
        }
        public IEnumerable<ProductDto> GetProducts(int groupId)
        {
            return new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "Product 1"
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "Product 2"
                }
                
            };
        }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}