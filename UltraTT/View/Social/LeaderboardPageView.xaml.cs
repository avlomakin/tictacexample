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
using UltraTT.ViewModel.Social;

namespace UltraTT.View.Social
{
    /// <summary>
    /// Interaction logic for LeaderboardPageView.xaml
    /// </summary>
    public partial class LeaderboardPageView : Page
    {
        private LeaderboardPageViewModel _viewModel;

        public LeaderboardPageView()
        {
            DataContext = new LeaderboardPageViewModel();
            InitializeComponent();
        }
    }
}
