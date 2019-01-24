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

namespace SPEANITool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void drawPixel(int x, int y, byte[] rgb)
        {
            Rectangle rect = new Rectangle();
            Grid.SetColumn(rect, x);
            Grid.SetRow(rect, y);
            rect.Fill = new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
            RenderGrid.Children.Add(rect);
        }

   
    }
}
