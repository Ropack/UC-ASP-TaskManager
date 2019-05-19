using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UC.ASP.TaskManager.BL.DTOs;

namespace UC.ASP.TaskManager.BO.Hubs
{
    public class IssuesHub : Hub
    {
        public async Task GetIssues()
        {
            var list = new List<IssueDto>()
            {
                new IssueDto()
                {
                    UserName = "John Doe",
                    CreatedDate = DateTime.Now,
                    Description = "Blah blah"
                },
                new IssueDto()
                {
                    UserName = "Mark Smith",
                    CreatedDate = DateTime.Now,
                    Description = "Blah blah again"
                }
            };
            JsonSerializerSettings dateFormatSettings = new JsonSerializerSettings
            {
                DateFormatString = "dd.MM.yyyy HH:mm:ss"
            };
            var json = JsonConvert.SerializeObject(list, dateFormatSettings);
            await Clients.All.SendAsync("UpdateIssues", list.Count, json);
        }
    }
}