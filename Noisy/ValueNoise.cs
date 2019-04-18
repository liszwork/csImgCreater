using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noisy
{
    class ValueNoise : Utility
    {
        Utility util;

        public Bitmap Create(int w = SIZE, int h = SIZE)
        {
            double[,] noise = new double[w, h];
            Bitmap bmp = new Bitmap(w, h);
            /*************************
                   v01         v11
                   .-----------.
               y  /           /
                 /           /
                /           /
               .-----------.
             v00     x     v01
            *************************/
            // 四隅の頂点をランダム値で決定
            float v00 = GetFRand();
            float v01 = GetFRand();
            float v10 = GetFRand();
            float v11 = GetFRand();

            for ( int y = 0; y < h; y++ )
            {
                float ty = (float)y / (float)h;
                float v0001 = Lerp(v00, v01, ty);
                float v1011 = Lerp(v10, v11, ty);
                for ( int x = 0; x < w; x++ )
                {
                    float tx = (float)x / (float)w;
                    int v = (int)(Lerp(v1011, v0001, tx) * 100);
                    Color color = Color.FromArgb(255, v, v, v);
                    bmp.SetPixel(x, y, color);
                }
            }

            return bmp;
        }
    }
}
