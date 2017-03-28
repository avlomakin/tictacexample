using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for HotSeatPageView.xaml
    /// </summary>
    public partial class HotSeatPageView : Page
    {
        private const int CellSize = 30;
        HotSeatPageViewModel viewModel;
        Image[] cells = new Image[81];
        Image[] bigCells = new Image[9];

        public HotSeatPageView()
        {
            viewModel = new HotSeatPageViewModel();
            DataContext = viewModel;
            InitializeComponent();

            CreateField();
        }

        private void CreateField()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i * 9 + j] = new Image();
                    var img = cells[i * 9 + j];
                    CreateImg(i, j, CreateButton(i, j), img);
                }
                bigCells[i] = new Image();
                CreateBigImg(i, bigCells[i]);
            }
        }

        private Button CreateButton(int x, int y)
        {
            Button btn = new Button
            {
                DataContext = viewModel,
                CommandParameter = new Tuple<int, int>(x, y),
                BorderBrush = Brushes.Red,
                Width = CellSize,
                Height = CellSize,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Padding = new Thickness(0),
                Margin = new Thickness(y * CellSize, x * CellSize, 0, 0)
            };

            Binding borderBinding = new Binding("IsMouseOver")
            {
                Source = btn,
                Mode = BindingMode.OneWay,
                ConverterParameter = new Tuple<Func<object, bool>, object>(viewModel.CheckCell, btn.CommandParameter),
                Converter = new BorderConverter()
            };

            btn.SetBinding(Control.BorderThicknessProperty, borderBinding);

            Binding clickBinding = new Binding("CellClick");
            btn.SetBinding(ButtonBase.CommandProperty, clickBinding);
            return btn;
        }

        private void CreateImg(int x, int y, Button btn, Image img)
        {
            btn.Content = img;
            img.Stretch = Stretch.Fill;
            img.DataContext = viewModel;

            Binding binding = new Binding($"PathToCellPict[{x * 9 + y}]")
            {
                Mode = BindingMode.OneWay
            };
            img.SetBinding(Image.SourceProperty, binding);

            img.Stretch = Stretch.Fill;

            FieldHolder.Children.Add(btn);

        }

        private void CreateBigImg(int position, Image img)
        {
            img.Width = CellSize * 3;
            img.Height = CellSize * 3;
            img.Margin = new Thickness((double)(position % 3) * CellSize * 3, (double)(position / 3) * CellSize * 3, 0, 0);
            img.Stretch = Stretch.Fill;
            img.DataContext = viewModel;
            Binding binding = new Binding($"PathToBigCellPict[{position}]")
            {
                Mode = BindingMode.OneWay
            };
            img.SetBinding(Image.SourceProperty, binding);

            BigCellsHolder.Children.Add(img);
        }
    }
}
