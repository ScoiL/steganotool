using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Steganography
{
    class SteganoLIB
    {
        public static string ExtractText(Bitmap bmp)
        {
            byte[] data = BitmapHelper.getBytes(bmp);
            StringBuilder builder=new StringBuilder();
            int i = 54;
            int argb = 0;
            byte c;
            while (true) 
            {
                c = 0;
                int j = 0;
                while(j<8)
                {
                    if ((argb == 3))
                    {
                        // Skip the alpha byte
                        argb = ((argb + 1) % 4);
                        i++;
                    }
                    
                        byte temp = data[i];
                        temp &= 0x01;
                        temp = (byte)(temp << j);
                        c |= temp;
                        argb = ((argb + 1) % 4);
                        i++;
                        j++;

                    
                }
                // Character is completed
                if (c == 0)
                    break;
                else
                    builder.Append((char)c);

            } 
            //for (int i = 54; i < data.Length - 1; i += 2)
            //{

            //    byte c = data[i];
            //    c = (byte)(c << 4);
            //    byte c2 = data[i + 1];
            //    c2 &= 0x0f;
            //    c |= c2;
            //    c &= 0x7f;
            //    if (c == 0)
            //        break;
            //    builder.Append((char)c);


            //}
            return builder.ToString();
        }

        public static Bitmap HideText(Bitmap imgSource, String txtMessage)
        {
            byte [] data=BitmapHelper.getBytes(imgSource);
            // Strip the least significant bit
            int i;
            for ( i = 54; i < data.Length; i++)
            {

                data[i] &= 0xfe;
            }

             i = 54;
             int argb = 0;
            foreach(char c in txtMessage.ToCharArray()){
              
                char ch = c;
                
                for (int b = 0; b < 8; b++)
                {
                    if (argb == 3)
                    {
                        // Skip the Alpha byte
                        i++;
                        argb = ((argb + 1) % 4);
                    }
                    data[i++] |= (byte)(ch & 0x01);
                    ch = (char)(ch >> 1);
                    argb = ((argb + 1) % 4);
                    
                }

            }
           
            return BitmapHelper.getBitmap(data);
              

        }
    }
}
