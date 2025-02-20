using _253503_Kudosh.Applicationn.ProjectUseCases.Commands.AddProject;
using _253503_Kudosh.Applicationn.ProjectUseCases.Queries.GetAllProjects;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253503_Kudosh.UI.ViewModels
{
    public partial class ProjectAddingViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private string _projectName = string.Empty;
        private string _projectCreator = string.Empty;
        private string _notifyString = string.Empty;
        private string _notifyStringColor = "White";
        public string ProjectName 
        { 
            get { return _projectName; }
            set { _projectName = value; OnPropertyChanged(); }
        } 
        public string ProjectCreator 
        { 
            get { return _projectCreator; }
            set { _projectCreator = value; OnPropertyChanged(); }
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
        public ProjectAddingViewModel(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [RelayCommand]
        async Task AddButtonClicked() => await AddProject();

        public async Task AddProject()
        {
            if(ProjectName == string.Empty) { NotifyString = "Name is Empty"; NotifyStringColor = "Red"; return; }
            if(ProjectCreator == string.Empty) { NotifyString = "Creator is Empty"; NotifyStringColor = "Red"; return;}
            await _mediator.Send(new AddProjectRequest(ProjectName, ProjectCreator));
            NotifyString = "Project added successfully!";
            NotifyStringColor = "Green";
            ProjectName = string.Empty;
            ProjectCreator = string.Empty;
        }
    }
}
