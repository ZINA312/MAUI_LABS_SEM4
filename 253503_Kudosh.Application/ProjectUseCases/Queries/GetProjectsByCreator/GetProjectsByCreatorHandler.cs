namespace _253503_Kudosh.Applicationn.ProjectUseCases.Queries.GetProjectsByCreator
{
    internal class GetProjectsByCreatorHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetProjectsByCreatorRequest, IEnumerable<ProjectEntity>>
    {
        public async Task<IEnumerable<ProjectEntity>> Handle(GetProjectsByCreatorRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.ProjectRepository.ListAsync(t => t.Creator.Equals(request.creator), cancellationToken);
        }
    }
}