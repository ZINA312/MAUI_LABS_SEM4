using _253503_Kudosh.UI.ViewModels;

namespace _253503_Kudosh.UI.Pages;

public partial class ProjectsPage : ContentPage
{
	public ProjectsPage(ProjectsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}