using System;

namespace UC.ASP.TaskManager.DAL.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}