using System;
using Newtonsoft.Json;

namespace UC.ASP.TaskManager.BL.DTOs
{
    public class IssueDto
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}