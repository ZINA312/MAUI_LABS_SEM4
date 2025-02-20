using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.Applicationn.ProjectUseCases.Commands.AddProject
{
    internal class AddProjectHandler : IRequestHandler<AddProjectRequest, ProjectEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddProjectHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ProjectEntity> Handle(AddProjectRequest request, CancellationToken cancellationToken)
        {
            ProjectEntity newProject = new ProjectEntity(request.Name, request.Creator);
            await _unitOfWork.ProjectRepository.AddAsync(newProject, cancellationToken);
            return newProject;
        }
    }
}
