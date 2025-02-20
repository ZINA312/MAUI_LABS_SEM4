using _253503_Kudosh.Applicationn.TaskUseCases.Commands.UpdateTask;
using _253503_Kudosh.Applicationn.TaskUseCases.Queries.GetTasksByProject;
using _253503_Kudosh.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace _253503_Kudosh.UI.ViewModels
{
    [QueryProperty(nameof(SerializedTask), "task")]
    public partial class TaskDetailsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        TaskEntity task;
        private string _newName = string.Empty;
        private string _newDescription = string.Empty;
        private string _newPercentage = string.Empty;
        private string _serializedTask = string.Empty;
        private string _notifyNameString = string.Empty;
        private string _notifyDescriptionString = string.Empty;
        private string _notifyPercentageString = string.Empty;
        private string _notifyNameStringColor = "White";
        private string _notifyDescriptionStringColor = "White";
        private string _notifyPercentageStringColor = "White";
        public TaskDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public TaskEntity Task
        {
            get => task;
            set { SetProperty(ref task, value); OnPropertyChanged(); }
        }
        public string NewName
        {
            get { return _newName; }
            set { SetProperty(ref _newName, value); OnPropertyChanged(); }
        }
        public string NewDescription
        {
            get { return _newDescription; }
            set { SetProperty(ref _newDescription, value); OnPropertyChanged(); }
        }
        public string NewPercentage
        {
            get { return _newPercentage; }
            set { SetProperty(ref _newPercentage, value); OnPropertyChanged(); }
        }
        public string NotifyNameString
        {
            get { return _notifyNameString; }
            set { SetProperty(ref _notifyNameString, value); OnPropertyChanged(); }
        }
        public string NotifyDescriptionString
        {
            get { return _notifyDescriptionString; }
            set { SetProperty(ref _notifyDescriptionString, value); OnPropertyChanged(); }
        }
        public string NotifyPercentageString
        {
            get { return _notifyPercentageString; }
            set { SetProperty(ref _notifyPercentageString, value); OnPropertyChanged(); }
        }
        public string NotifyNameStringColor
        {
            get { return _notifyNameStringColor; }
            set { SetProperty(ref _notifyNameStringColor, value); OnPropertyChanged(); }
        }
        public string NotifyDescriptionStringColor
        {
            get { return _notifyDescriptionStringColor; }
            set { SetProperty(ref _notifyDescriptionStringColor, value); OnPropertyChanged(); }
        }
        public string NotifyPercentageStringColor
        {
            get { return _notifyPercentageStringColor; }
            set { SetProperty(ref _notifyPercentageStringColor, value); OnPropertyChanged(); }
        }
        public string SerializedTask
        {
            get => _serializedTask;
            set
            {
                _serializedTask = value;
                task = JsonSerializer.Deserialize<TaskEntity>(Uri.UnescapeDataString(_serializedTask));
            }
        }
        [RelayCommand]
        async Task ImageChangeButtonClicked() => await SelectImageAsync();
        [RelayCommand]
        async Task NameChangeButtonClicked() => await UpdateName();
        [RelayCommand]
        async Task DescriptionChangeButtonClicked() => await UpdateDescription();
        [RelayCommand]
        async Task PercentageChangeButtonClicked() => await UpdatePercentage();

        [RelayCommand]
        async Task UpdateTaskDetails() => await GetTaskDetails();
        public async Task GetTaskDetails()
        {
            Task = JsonSerializer.Deserialize<TaskEntity>(Uri.UnescapeDataString(_serializedTask));
        }
        public async Task UpdateName()
        {
            if(NewName == string.Empty) { NotifyNameString = "Name is Empty!"; NotifyNameStringColor = "Red"; return; }
            Task.Name = NewName;
            NewName = string.Empty;
            await _mediator.Send(new UpdateTaskRequest(task));
            Task = Task;
            NotifyNameString = "Name updated successfully!"; NotifyNameStringColor = "Green";
        }
        public async Task UpdateDescription()
        {
            if (NewDescription == string.Empty) { NotifyDescriptionString = "Name is Empty!"; NotifyDescriptionStringColor = "Red"; return; }
            Task.Description = NewDescription;
            NewDescription = string.Empty;
            await _mediator.Send(new UpdateTaskRequest(task));
            Task = Task;
            NotifyDescriptionString = "Description updated successfully!"; NotifyDescriptionStringColor = "Green";
        }
        public async Task UpdatePercentage()
        {
            if (NewPercentage == string.Empty) { NotifyPercentageString = "Percentage is Empty!"; NotifyPercentageStringColor = "Red"; return; }
            if(!int.TryParse(NewPercentage, out var percentage) || percentage < 0 || percentage > 100) { NotifyPercentageString = "Incorrect input!"; NotifyPercentageStringColor = "Red"; return; }
            Task.Percentage = percentage;
            NewPercentage = string.Empty;
            await _mediator.Send(new UpdateTaskRequest(task));
            Task = Task;
            NotifyPercentageString = "Percentage updated successfully!"; NotifyPercentageStringColor = "Green";
        }
        public async Task SelectImageAsync()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Choose image"
            });

            if (result != null)
            {
                string imagesFolder = "";
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        imagesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "Images");
                        break;
                    case Device.Android:
                        imagesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Images");
                        break;
                    case Device.UWP:
                        imagesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Images");
                        break;
                }

                if (!Directory.Exists(imagesFolder))
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                        Directory.CreateDirectory(imagesFolder);
                    });
                }
                var newImagePath = $"{imagesFolder}\\{Task.Id}.png";
                var oldImagePath = result.FullPath;
                if (File.Exists(newImagePath))
                {
                    File.Delete(newImagePath);
                }
                File.Move(oldImagePath, newImagePath);
                Task = Task;
            }
        }
    }
}
