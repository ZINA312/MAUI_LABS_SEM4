using _253503_Kudosh.UI.ViewModels;

namespace _253503_Kudosh.UI.Pages;

public partial class TaskAdding : ContentPage
{
	public TaskAdding(TaskAddingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}