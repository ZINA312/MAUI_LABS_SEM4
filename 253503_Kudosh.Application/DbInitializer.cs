using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Applicationn
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();
            for (int i = 1; i < 10; i++)
            {
                ProjectEntity project = new($"Project {i}", $"Creator {i}");
                await unitOfWork.ProjectRepository.AddAsync(project);
            }
            await unitOfWork.SaveAllAsync();
            Random random = new Random();
            for(int i = 1;i < 10; i++)
            {
                for(int j = 1; j < 5; j++)
                {
                    TaskEntity task = new($"Task {j}", $"Description {j}");
                    task.Percentage = random.Next(1,101); 
                    task.AddToProject(i);
                    await unitOfWork.TaskRepository.AddAsync(task);
                }
            }
            await unitOfWork.SaveAllAsync();
        }
    }
}
