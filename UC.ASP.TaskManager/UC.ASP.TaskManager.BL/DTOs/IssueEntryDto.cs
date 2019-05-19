using System;

namespace UC.ASP.TaskManager.BL.DTOs
{
    public class IssueEntryDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserEmail { get; set; }
    }
}