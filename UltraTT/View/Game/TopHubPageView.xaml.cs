using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltraTT.ViewModel.Game;

namespace UltraTT.View.Game
{
    /// <summary>
    /// Interaction logic for TopHubPageView.xaml
    /// </summary>
    public partial class TopHubPageView : Page
    {
        private readonly TopHubPageViewModel _viewModel;
        public TopHubPageView()
        {
            InitializeComponent();
            _viewModel = new TopHubPageViewModel();
            DataContext = _viewModel;
        }
    }
}
