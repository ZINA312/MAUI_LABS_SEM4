namespace _253503_Kudosh.Applicationn.TaskUseCases.Queries.GetTasksByProject
{
    internal class GetTaskByProjectHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetTasksByProjectRequest, IEnumerable<TaskEntity>>
    {
        public async Task<IEnumerable<TaskEntity>> Handle(GetTasksByProjectRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.TaskRepository.ListAsync(t => t.ProjectId.Equals(request.Id), cancellationToken);

        }
    }
}
