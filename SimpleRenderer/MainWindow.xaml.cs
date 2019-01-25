using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace SimpleRenderer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Renderer renderer;

        private delegate Task doStuff();

        public MainWindow()
        {
            InitializeComponent();
            this.renderer = new Renderer(this.RenderGrid);

            RenderGrid.Dispatcher.BeginInvoke(DispatcherPriority.Background, new doStuff(renderer.doStuff));
            //this.renderer.doStuff();
        }


   
    }
}
