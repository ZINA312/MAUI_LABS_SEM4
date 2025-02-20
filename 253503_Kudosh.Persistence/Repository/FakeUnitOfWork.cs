using _253503_Kudosh.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Persistence.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly FakeProjectRepository _projectRepository;
        private readonly FakeTaskRepository _taskRepository;

        public FakeUnitOfWork()
        {
            _projectRepository = new FakeProjectRepository();
            _taskRepository = new FakeTaskRepository();
        }

        public IRepository<ProjectEntity> ProjectRepository => _projectRepository;

        public IRepository<TaskEntity> TaskRepository => _taskRepository;

        public Task CreateDataBaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteDataBaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
