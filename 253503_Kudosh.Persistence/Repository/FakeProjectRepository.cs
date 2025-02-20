using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Persistence.Repository
{
    public class FakeProjectRepository : IRepository<ProjectEntity>
    {
        List<ProjectEntity> _projects;

        public FakeProjectRepository() 
        {
            _projects = new List<ProjectEntity>();
            var project = new ProjectEntity("Проект 1", "Создатель 1");
            project.Id = 1;
            _projects.Add(project);
            project = new ProjectEntity("Проект 2", "Создатель 2");
            project.Id = 2;
            _projects.Add(project);
        }
        public Task AddAsync(ProjectEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProjectEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectEntity> FirstOrDefaultAsync(Expression<Func<ProjectEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<ProjectEntity, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProjectEntity>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _projects);
        }

        public Task<IReadOnlyList<ProjectEntity>> ListAsync(Expression<Func<ProjectEntity, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<ProjectEntity, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProjectEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
