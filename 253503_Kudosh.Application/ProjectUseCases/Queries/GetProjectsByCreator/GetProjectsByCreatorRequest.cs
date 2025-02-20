namespace _253503_Kudosh.Applicationn.ProjectUseCases.Queries.GetProjectsByCreator
{
    public sealed record GetProjectsByCreatorRequest(string creator) : IRequest<IEnumerable<ProjectEntity>>
    { }
}
