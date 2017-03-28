using System.Windows.Controls;
using UltraTT.ViewModel.Login;

namespace UltraTT.View.Login
{
    /// <summary>
    /// Interaction logic for AuthPageView.xaml
    /// </summary>
    public partial class AuthPageView : Page
    {
        AuthPageViewModel viewModel;
        public AuthPageView()
        {
            viewModel = new AuthPageViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
