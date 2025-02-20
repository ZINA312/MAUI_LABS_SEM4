using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Persistence.Repository
{
    public class FakeTaskRepository : IRepository<TaskEntity>
    {

        List<TaskEntity> _tasks = new List<TaskEntity>();

        public FakeTaskRepository()
        {
            Random random = new Random();
            for (int i = 1; i <= 2; i++) 
            { 
                for (int j = 0; j < 10; j++)
                {
                    var task = new TaskEntity($"Задание {j}", $"Описание {j}");
                    task.Percentage = random.Next(101);
                    task.AddToProject(i);
                    task.AddToProject(i);
                    _tasks.Add(task);
                }
            }   
        }

        public Task AddAsync(TaskEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TaskEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TaskEntity> FirstOrDefaultAsync(Expression<Func<TaskEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TaskEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<TaskEntity, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TaskEntity>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<TaskEntity>> ListAsync(Expression<Func<TaskEntity, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<TaskEntity, object>>[]? includesProperties)
        {
            var data = _tasks.AsQueryable();
            return data.Where(filter).ToList();
        }

        public Task UpdateAsync(TaskEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
