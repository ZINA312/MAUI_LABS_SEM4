using _253503_Kudosh.UI.Pages;

namespace _253503_Kudosh.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute(nameof(TaskDetails), typeof(TaskDetails));
            InitializeComponent();
        }
    }
}
