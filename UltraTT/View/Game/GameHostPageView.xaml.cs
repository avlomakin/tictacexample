using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

namespace UltraTT.View.Game
{
    /// <summary>
    /// Interaction logic for GameHostPageView.xaml
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand)]
    public partial class GameHostPageView : Page, IContentHolder
    {
        public GameHostPageView()
        {
            InitializeComponent();
            WorkingFrame.Content = new HotSeatPageView();
        }

        public void ShowContent(object content)
        {
            WorkingFrame.Content = content;
        }
    }
}
