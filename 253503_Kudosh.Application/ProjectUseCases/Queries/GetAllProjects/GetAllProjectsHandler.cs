
namespace _253503_Kudosh.Applicationn.ProjectUseCases.Queries.GetAllProjects
{
    internal class GetAllProjectsHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetAllProjectsRequest, IEnumerable<ProjectEntity>>
    {
        public async Task<IEnumerable<ProjectEntity>> Handle(GetAllProjectsRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.ProjectRepository.ListAllAsync(cancellationToken);
        }
    }
}
