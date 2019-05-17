using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UC.ASP.TaskManager.DAL.Entities
{
    public class IssueComment : IEntity<int>, ITimeTrackable
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        
        [ForeignKey(nameof(IssueId))]
        public virtual Issue Issue { get; set; }
        public int IssueId { get; set; }
    }
}