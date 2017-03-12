using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SuperTic.ViewModel;

namespace SuperTic.View 
{
    /// <summary>
    /// Interaction logic for HotSeatView.xaml
    /// </summary>
    public partial class HotSeatView : Window
    {
        private const int CellSize = 30;
        HotSeatViewModel viewModel;
        Image[] cells = new Image[81];

        public HotSeatView()
        {
            viewModel = new HotSeatViewModel();
            DataContext = viewModel;
            InitializeComponent();

            FillField();

            
        }


        private void FillField()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i * 9 + j] = new Image();
                    InitializeCell(i, j, cells[i * 9 + j]);
                }
            }
        }
        private void InitializeCell(int x, int y, Image img)
        {
            Button btn = new Button
            {
                Content = img,
                DataContext = viewModel,
                CommandParameter = new Tuple<int, int>(x, y),
                BorderBrush = Brushes.Red,
                Width = CellSize,
                Height = CellSize,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Padding = new Thickness(0),
                Margin = new Thickness(y*CellSize, x*CellSize, 0, 0)
            };

            Binding borderBinding = new Binding("IsMouseOver")
            {
                Source = btn,
                Mode = BindingMode.OneWay,
                ConverterParameter = new Tuple<Func<object, bool>, object>(viewModel.CheckCell, btn.CommandParameter),
                Converter = new BorderConverter()
            };

            btn.SetBinding(BorderThicknessProperty, borderBinding);

            Binding clickBinding = new Binding("CellClick");
            btn.SetBinding(Button.CommandProperty, clickBinding);

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
    }
}
