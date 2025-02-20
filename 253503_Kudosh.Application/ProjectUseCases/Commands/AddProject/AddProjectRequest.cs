using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Applicationn.ProjectUseCases.Commands.AddProject
{
    public sealed record AddProjectRequest(string Name, string Creator) : IRequest<ProjectEntity>
    { }
}
