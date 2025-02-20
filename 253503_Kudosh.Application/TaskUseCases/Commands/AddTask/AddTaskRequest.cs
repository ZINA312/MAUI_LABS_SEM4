using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Applicationn.TaskUseCases.Commands.AddTask
{
    public sealed record AddTaskRequest(string Name, string Description, int? ProjectId) : IRequest<TaskEntity>
    { }
}
