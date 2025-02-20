using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Applicationn.TaskUseCases.Commands.UpdateTask
{
    public sealed record UpdateTaskRequest(TaskEntity UpdatedTask) : IRequest<TaskEntity>
    { }
}
