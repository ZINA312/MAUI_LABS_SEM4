namespace _253503_Kudosh.Applicationn.TaskUseCases.Queries.GetTasksByProject
{
    public sealed record GetTasksByProjectRequest(int Id) : IRequest<IEnumerable<TaskEntity>>
    { }
}
