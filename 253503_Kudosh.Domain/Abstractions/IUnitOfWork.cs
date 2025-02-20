using _253503_Kudosh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<ProjectEntity> ProjectRepository { get; }
        IRepository<TaskEntity> TaskRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
