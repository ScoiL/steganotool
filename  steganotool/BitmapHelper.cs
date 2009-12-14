using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Steganography
{
    class BitmapHelper
    {
        
        public static  byte [] getBytes(Bitmap imgSource)
        {

            MemoryStream ms = new MemoryStream();
            imgSource.Save(ms, ImageFormat.Bmp);
            return ms.ToArray();
        }
        public static Bitmap getBitmap(byte [] arrData){
            MemoryStream ms = new MemoryStream(arrData);

            Bitmap bmp = new Bitmap(ms);
          
            return bmp;
        }

    }
}
