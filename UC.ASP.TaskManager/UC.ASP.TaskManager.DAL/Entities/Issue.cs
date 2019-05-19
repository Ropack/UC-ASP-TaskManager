using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UC.ASP.TaskManager.DAL.Entities
{
    public class Issue : IEntity<int>, ITimeTrackable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Resolved { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserEmail { get; set; }
        
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual ICollection<IssueComment> IssueComments { get; set; }
    }
}
