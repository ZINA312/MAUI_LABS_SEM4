using _253503_Kudosh.Applicationn.ProjectUseCases.Queries.GetAllProjects;
using _253503_Kudosh.Applicationn.TaskUseCases.Queries.GetTasksByProject;
using _253503_Kudosh.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration.Json;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _253503_Kudosh.UI.ViewModels
{
    public partial class ProjectsViewModel : ObservableObject
    {

        private readonly IMediator _mediator;
        public ProjectsViewModel(IMediator mediator)
        {
            Tasks.Clear();
            _mediator = mediator;
        }
        public ObservableCollection<ProjectEntity> Projects { get; set; } = new();
        public ObservableCollection<TaskEntity> Tasks { get; set; } = new();
        [ObservableProperty]
        ProjectEntity selectedProject;
        [RelayCommand]
        async Task UpdateProjectsList() => await GetProjects();
        [RelayCommand]
        async Task UpdateTasksList() => await GetTasks();
        [RelayCommand]
        async void ShowDetails(TaskEntity task) => await GotoDetailsPage(task);
        public async Task GetProjects()
        {
            Tasks.Clear();
            var projects = await _mediator.Send(new GetAllProjectsRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Projects.Clear();
                foreach (var project in projects)
                    Projects.Add(project);
            }); 
        }
        public async Task GetTasks()
        {
            if(SelectedProject == null) { return; }
            var tasks = await _mediator.Send(new GetTasksByProjectRequest(SelectedProject.Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Tasks.Clear();
                foreach (var task in tasks)
                    Tasks.Add(task);
            });
        }
        private async Task GotoDetailsPage(TaskEntity task)
        {
            Tasks.Clear();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 64
            };
            var serializedTask = JsonSerializer.Serialize(task, options);
            await Shell.Current.GoToAsync($"{nameof(TaskDetails)}?task={Uri.EscapeDataString(serializedTask)}");
        }
    }
}

