using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UC.ASP.TaskManager.DAL.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}