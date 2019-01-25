using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleRenderer
{
    class Renderer
    {
        private Grid grid;

        public Renderer(Grid grid)
        {
            this.grid = grid;
        }

        public void drawPixel(int x, int y, byte[] rgb)
        {
            Rectangle rect = new Rectangle();
            Grid.SetColumn(rect, x);
            Grid.SetRow(rect, y);
            rect.Fill = new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
            this.grid.Children.Add(rect);
        }

        public async Task doStuff()
        {
            Random rnd = new Random();
            for (int k = 0; k < 100; k++)
            {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        drawPixel(i, j, new byte[] { (byte)rnd.Next(0, 255), (byte)(rnd.Next(0, 255)), (byte)(rnd.Next(0, 255)) });
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}
