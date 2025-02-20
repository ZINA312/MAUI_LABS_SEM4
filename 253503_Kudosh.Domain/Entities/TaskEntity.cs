using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Domain.Entities
{
    public class TaskEntity : Entity
    {
        private TaskEntity() { }
        public TaskEntity(string name, string description)
        {
            Name = name;
            Percentage = 0;
            Description = description;
            Created = DateTime.Now;
        }
        public string Name { get; set; } = "Default_Name";
        public int Percentage { get; set; } = 0;
        public string Description { get; set; } = "Default_Description";
        public DateTime Created { get; private set; } = DateTime.Now;
        public int? ProjectId { get; private set; }
        public ProjectEntity Project { get; set; }
        public void AddToProject(int? projectId)
        {
            if (projectId < 0) return;
            this.ProjectId = projectId;
        }
    }
}
