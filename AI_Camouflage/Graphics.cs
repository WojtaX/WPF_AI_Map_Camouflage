using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Zord_4_MC_v1_WL
{
   static class Graphics
    {
        public enum Ikony
        {
            Zord4,
            joker,
            mapa,
        }
       

       public static System.Windows.Media.ImageBrush SettingBackground(Ikony ikona)
       {

            string path = "pack://application:,,,/images/" + ikona.ToString() + ".png";

            return (new ImageBrush(new BitmapImage(new Uri(path))));

        }

       public static  System.Windows.Controls.Image SettingIcon(Ikony ikona)
        {
            return (new System.Windows.Controls.Image { Source = new BitmapImage(new Uri(@"pack://application:,,,/images/" + ikona + ".png")) });

        }

    }
}
