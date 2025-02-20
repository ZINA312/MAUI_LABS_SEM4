using _253503_Kudosh.Applicationn.ProjectUseCases.Queries.GetAllProjects;
using _253503_Kudosh.Applicationn.TaskUseCases.Commands.AddTask;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.UI.ViewModels
{
    public partial class TaskAddingViewModel : ObservableObject
    {
        private string _taskName = string.Empty;
        private string _taskDescription = string.Empty;
        private readonly IMediator _mediator;
        private string _notifyString = string.Empty;
        private string _notifyStringColor = "White";
        public ObservableCollection<ProjectEntity> Projects { get; set; } = new();
        [ObservableProperty]
        ProjectEntity ?selectedProject = null;
        public TaskAddingViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; OnPropertyChanged(); }
        }
        public string TaskDescription
        {
            get { return _taskDescription; }
            set { _taskDescription = value; OnPropertyChanged(); }
        }
        public string NotifyString
        {
            get { return _notifyString; }
            set { _notifyString = value; OnPropertyChanged(); }
        }
        public string NotifyStringColor
        {
            get { return _notifyStringColor; }
            set { _notifyStringColor = value; OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task AddButtonClicked() => await AddTask();

        [RelayCommand]
        async Task UpdateProjectsList() => await GetProjects();

        public async Task GetProjects()
        {
            var projects = await _mediator.Send(new GetAllProjectsRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Projects.Clear();
                foreach (var project in projects)
                    Projects.Add(project);
            });
        }

        public async Task AddTask()
        {
            if(TaskName == string.Empty) { NotifyString = "Name is Empty"; NotifyStringColor = "Red"; return; }
            if(TaskDescription == string.Empty) { NotifyString = "Description is Empty"; NotifyStringColor = "Red"; return; }
            if(selectedProject == null) { NotifyString = "Choose a project!"; NotifyStringColor = "Red"; return; }
            await _mediator.Send(new AddTaskRequest(TaskName, TaskDescription, selectedProject.Id));
            NotifyString = "Task added successfully";
            NotifyStringColor = "Green";
            TaskName = string.Empty;
            TaskDescription = string.Empty;
        }
    }
}
