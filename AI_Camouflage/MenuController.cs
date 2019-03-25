using System;
using System.Windows;
using System.Windows.Media;

namespace Zord_4_MC_v1_WL
{
    static class MenuController
    {
        public enum Nazwy
        {
            Camouflage,
            Selected,
            Clear,
            Start,

        }

        public static void AddMenuElement(String name, int height, System.Windows.Controls.Image Ico, RoutedEventHandler Click, Map map)
        {

            System.Windows.Controls.MenuItem MenuElement = new System.Windows.Controls.MenuItem
            {
                Header = name,
                Height = height,
                Icon = Ico

            };
            MenuElement.Click += Click;
            map.MainWin.menu.Items.Add(MenuElement);
        }

        public static void EmptyClick(object sender, RoutedEventArgs e) { throw new NotImplementedException(); }

        public static void Hovering(object sender, RoutedEventArgs e)
        {
            GridPoint ctrl = (GridPoint)sender;
            ctrl.Opacity = 0.5;
            ctrl.BorderThickness = new Thickness(2, 2, 2, 2);
            ctrl.BorderBrush = Brushes.SteelBlue;
        }

     public static  void Out(object sender, RoutedEventArgs e)
        {
            GridPoint ctrl = (GridPoint)sender;
            ctrl.Opacity = 1.0;
            ctrl.BorderThickness = new Thickness(0, 0, 0, 0);
        }
    }
}
