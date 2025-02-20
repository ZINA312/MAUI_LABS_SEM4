using _253503_Kudosh.UI.ViewModels;

namespace _253503_Kudosh.UI.Pages;

public partial class ProjectAdding : ContentPage
{
	public ProjectAdding(ProjectAddingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}