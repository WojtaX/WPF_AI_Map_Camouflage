using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Zord_4_MC_v1_WL
{
   static class MapController
    {
        
        public static Bitmap Converting2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
        
    }
}



