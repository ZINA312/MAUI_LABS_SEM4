using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Domain.Entities
{
    public class ProjectEntity : Entity
    {
        private ProjectEntity() { }
        public ProjectEntity(string name, string creator) 
        {
            Name = name;
            Creator = creator;
        }
        public string Name { get; set; } = "Default_Name";
        public string Creator { get; private set; } = "Default_Creator";
        private List<TaskEntity> _tasks { get; set; } = [];
        public List<TaskEntity> Tasks { get => _tasks; }
    }
}
