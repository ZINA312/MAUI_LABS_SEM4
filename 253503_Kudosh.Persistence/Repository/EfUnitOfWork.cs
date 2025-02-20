using _253503_Kudosh.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Persistence.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<ProjectEntity>> _projectRepository;
        private readonly Lazy<IRepository<TaskEntity>> _taskRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _projectRepository = new Lazy<IRepository<ProjectEntity>>(() =>
            new EfRepository<ProjectEntity>(context));
            _taskRepository = new Lazy<IRepository<TaskEntity>>(() =>
            new EfRepository<TaskEntity>(context));
        }
        public IRepository<ProjectEntity> ProjectRepository
        => _projectRepository.Value;
        public IRepository<TaskEntity> TaskRepository
         => _taskRepository.Value;
        public async Task CreateDataBaseAsync() =>
         await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() =>
         await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() =>
         await _context.SaveChangesAsync();
    }
}
