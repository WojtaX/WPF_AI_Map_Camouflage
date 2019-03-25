using System;
using System.Drawing;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Zord_4_MC_v1_WL
{
    class ControllerMC 
    {
      
        Map Map;
        MonteCarloSampler MonteCarlo;
        Bitmap BackgroundCamouflage;
      
        public Map Mapka
        {
            get { return this.Map; }
            set { this.Map = value; }
        }

        public ControllerMC(MainWindow MainWin)
        {
            StartingNewSession(MainWin);
            this.BackgroundCamouflage = MapController.Converting2Bitmap(new BitmapImage(new Uri(@"pack://application:,,,/images/mapa.png")));
            SettingMenu();
        }

        private void Controller_Click(object sender, RoutedEventArgs e)
        {
            Update();
            GridPoint ctrl = (GridPoint)sender;

            if (ctrl.Background == System.Windows.Media.Brushes.Transparent)
            {
                MonteCarlo.SetPoint(ctrl);
                Update();
                ctrl.selected = true;
                ctrl.Background = Graphics.SettingBackground(Graphics.Ikony.joker);
            }
            else
            {
                MonteCarlo.UncheckPoint(ctrl);
                Update();
                ctrl.Background = System.Windows.Media.Brushes.Transparent;
                ctrl.selected = false;
            }
        }

       private void StartCamouflage(object sender, RoutedEventArgs e)
        {
            
            try { CamouflagingBackground(); }
            catch(Exception b) { System.Windows.MessageBox.Show("Błąd: Obszar niedozwolony. Wyczyść zaznaczenie "+b.Message , "Błąd zaznaczenia", MessageBoxButton.OK, MessageBoxImage.Warning); }
          
        }
        
        private void CamouflagingBackground()
        {
            Bitmap Camouflaged = MonteCarlo.Algorithm(BackgroundCamouflage);
            var MapSource = Imaging.CreateBitmapSourceFromHBitmap(Camouflaged.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            MonteCarlo.DeletingSelectedPoints();

            StartingNewSession(Map.MainWin);
            this.Map.MainWin.Background = new ImageBrush(MapSource);
        }

        
      
        private void Update()
        {
            try { this.Map.MainWin.menu.Items[2] = MonteCarlo.UpdateCheckedPoints.Count.ToString(); }
           catch(Exception e) {System.Windows.MessageBox.Show("System Halted", "Panic error", MessageBoxButton.YesNoCancel, MessageBoxImage.Error); } 
        }

        private void SettingMenu()
        {
            MenuController.AddMenuElement(MenuController.Nazwy.Camouflage.ToString(), 40, Graphics.SettingIcon(Graphics.Ikony.Zord4), StartCamouflage, Mapka);
            MenuController.AddMenuElement(MenuController.Nazwy.Selected.ToString(), 40, null, MenuController.EmptyClick, Mapka);
            MenuController.AddMenuElement(this.MonteCarlo.UpdateCheckedPoints.Count.ToString(), 40, null, MenuController.EmptyClick, Mapka);
            MenuController.AddMenuElement(MenuController.Nazwy.Clear.ToString(), 40, null, Cleaning, Mapka);

        }

        private void Cleaning(object sender, RoutedEventArgs e)
        {
            foreach (GridPoint SelectedPoint in this.MonteCarlo.UpdateCheckedPoints)
            {
                SelectedPoint.Background = System.Windows.Media.Brushes.Transparent;
                SelectedPoint.selected = false;
            }
            
            this.MonteCarlo.DeletingSelectedPoints();
            this.BackgroundCamouflage = MapController.Converting2Bitmap(new BitmapImage(new Uri(@"pack://application:,,,/images/mapa.png")));
            Map.MainWin.Background = Graphics.SettingBackground(Graphics.Ikony.mapa);
            Update();
            StartingNewSession(this.Map.MainWin);
        }

        private void StartingNewSession(MainWindow MainWin)
        {
            this.Map = new Map(MainWin, 20, 800, 800);
            this.Map.MainWin.mapa = this.Map;

            this.MonteCarlo = new MonteCarloSampler(10000, 5, this.Map.gridSize);

            for (int i = 0; i < Map.gridSize; i++)
            {
                for (int j = 0; j < Map.gridSize; j++)
                {
                    Map.Grid[i][j].Click += Controller_Click;
                }
            }
        }
    }
}
