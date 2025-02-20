using _253503_Kudosh.UI.ViewModels;

namespace _253503_Kudosh.UI.Pages;
public partial class TaskDetails : ContentPage
{
	public TaskDetails(TaskDetailsViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;
	}

}