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
using CalcBinding;

namespace UltraTT.View.Social
{
    /// <summary>
    /// Логика взаимодействия для UserPageView.xaml
    /// </summary>
    public partial class UserPageView : Page
    {
        private UserPageViewModel _viewModel;
        public UserPageView()
        {
            _viewModel = new UserPageViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}
