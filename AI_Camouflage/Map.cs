using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Zord_4_MC_v1_WL
{
    public class Map
    {
      
        MainWindow mw;
        int GridSize;
        int GridHeight;
        int GridWidth;

        public int gridSize
        {
            get { return GridSize; }
            set { this.GridSize = value; }
        }

        int Gridheight
        {
            get { return GridHeight; }
            set { this.GridHeight = value; }
        }

        int Gridwidth
        {
            get { return GridWidth; }
            set { this.GridWidth = value; }
        }

        List<List<GridPoint>> grid;

        public List<List<GridPoint>> Grid
        {
            get { return grid; }
            set { this.grid = value; }
        }

        public MainWindow MainWin
        {
            get { return mw; }
            set { this.mw = value; }
        }

        public Map(MainWindow mw, int GridS, int height, int width)
        {
            MainWin = mw;

           gridSize = GridS;
            Gridheight = height / GridS;
            Gridwidth = width / GridS;

            MainWin.Title = "Artificial Intelligence Camouflage";
            MainWin.Height = height + 75;
            MainWin.Width = width + 15;
            MainWin.ResizeMode = ResizeMode.NoResize;
            MainWin.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/images/mapa.png")));

            Grid = new List<List<GridPoint>>();

            for (int i = 0; i < GridS; i++)
            {

                List<GridPoint> SubList = new List<GridPoint>();
                for (int j = 0; j < GridS; j++)
                {
                    GridPoint button = new GridPoint();
                    button.X = Gridwidth * j + Gridwidth / 2;
                    button.Y = Gridheight * i + Gridheight / 2;
                    button.Height = Gridheight;
                    button.Width = Gridwidth;
                    button.Background = Brushes.Transparent;
                    button.BorderThickness = new Thickness(0, 0, 0, 0);

                    button.MouseEnter +=MenuController.Hovering;
                    button.MouseLeave += MenuController.Out;

                   
                    Canvas.SetTop(button, i * Gridheight);
                    Canvas.SetLeft(button, j * Gridwidth);
                    MainWin.root.Children.Add(button);
                    SubList.Add(button);

                }
                Grid.Add(SubList);
            }
        }

 

    }
}
