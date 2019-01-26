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
        private readonly SynchronizationContext syncContext;

        public Renderer(Grid grid)
        {
            this.grid = grid;
            syncContext = SynchronizationContext.Current;

            drawLineMPS(0.4f, 0.3f, 43.5f, 16.21f);
        }

        public void drawCoordinateAxes(byte[] color)
        {
            for (int i = -50; i < 50; i++)
            {
                drawPixel(i, 0, color);
                drawPixel(0, i, color);
            }

        }

        public async void drawPixel(int x, int y, byte[] rgb)
        {
            Rectangle rect = new Rectangle();
            Grid.SetColumn(rect, x + 50);
            Grid.SetRow(rect, 50 - y);
            rect.Fill = new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
            this.grid.Children.Add(rect);
        }

        public void clearCanvas()
        {
            this.grid.Children.Clear();
        }


        public async void doStuff()
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
                    await Task.Delay(1);
                    if (i % 12 == 0) clearCanvas();

                }

            }

        }

        public async void drawLineMPS(float xa, float ya, float xe, float ye)
        {
            byte[] color = { 0x2B, 0x3A, 0x42 };

            int XA = (int)Math.Round(xa);
            int XE = (int)Math.Round(xe);
            int YA = (int)Math.Round(ya);
            int YE = (int)Math.Round(ye);

            int deltaX = XE - XA;
            int deltaY = YE - YA;

            int delta = deltaY * 2 - deltaX;
            int incrEast = deltaY * 2;
            int incrNorthEast = (deltaY - deltaX) * 2;

            int x = XA;
            int y = YA;
            drawPixel(x, y, color);

            while (x < XE)
            {
                if (delta <= 0)
                {
                    delta += incrEast;
                    x++;
                }
                else
                {
                    delta += incrNorthEast;
                    x++;
                    y++;
                }
                drawPixel(x, y, color);
                await Task.Delay(10);
            }
        }
    }
}
