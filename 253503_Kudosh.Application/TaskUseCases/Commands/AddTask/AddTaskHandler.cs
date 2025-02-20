using _253503_Kudosh.Applicationn.ProjectUseCases.Commands.AddProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Applicationn.TaskUseCases.Commands.AddTask
{
    internal class AddTaskHandler : IRequestHandler<AddTaskRequest, TaskEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskEntity> Handle(AddTaskRequest request, CancellationToken cancellationToken)
        {
            TaskEntity newTask = new TaskEntity(request.Name, request.Description);
            if(request.ProjectId != null) { newTask.AddToProject(request.ProjectId); }
            await _unitOfWork.TaskRepository.AddAsync(newTask, cancellationToken);
            return newTask;
        }
    }
}
