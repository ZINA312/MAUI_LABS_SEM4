using _253503_Kudosh.Applicationn.TaskUseCases.Commands.AddTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Applicationn.TaskUseCases.Commands.UpdateTask
{
    internal class UpdateTaskHandler : IRequestHandler<UpdateTaskRequest, TaskEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskEntity> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TaskRepository.GetByIdAsync(request.UpdatedTask.Id, cancellationToken);

            task.Name = request.UpdatedTask.Name;
            task.Description = request.UpdatedTask.Description;
            task.Percentage = request.UpdatedTask.Percentage;

            await _unitOfWork.TaskRepository.UpdateAsync(task, cancellationToken);
            await _unitOfWork.SaveAllAsync();

            return task;
        }
    }
}
