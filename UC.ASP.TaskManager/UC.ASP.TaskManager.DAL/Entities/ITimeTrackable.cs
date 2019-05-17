using System;

namespace UC.ASP.TaskManager.DAL.Entities
{
    public interface ITimeTrackable
    {
        DateTime CreatedDate { get; set; }
    }
}