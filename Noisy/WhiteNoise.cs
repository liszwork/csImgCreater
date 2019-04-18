using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noisy
{
    class WhiteNoise : Utility
    {
        // ホワイトノイズの出力
        public Bitmap Create(int w = SIZE, int h = SIZE)
        {
            double[,] noise = new double[w, h];
            Bitmap bmp = new Bitmap(w, h);
            for ( int y = 0; y < h; y++ )
            {
                string msg = "@";
                for ( int x = 0; x < w; x++ )
                {
                    float value = GetFRand();
                    msg += value.ToString() + " ";

                    int v = (int)(value * 100.0);
                    Color color = Color.FromArgb(255, v, v, v);
                    bmp.SetPixel(x, y, color);
                }
                //UpdateTextLog(msg);
            }
            return bmp;
#if false
            /*  実験失敗
                int completeLine = 0;
                int task1Line = 0;
                bool isTask1Working = false;
                //for ( int y = 0; y < h; y++ )
                while ( true )
                {
                    // 1タスクで1列を処理してもらう
                    await Task.Run(() => {
                        if ( isTask1Working )
                        {
                            for ( int x = 0; x < w; x++ )
                            {
                                float value = GetFRand();
                                int v = (int)(value * 100.0);
                                Color color = Color.FromArgb(255, v, v, v);
                                this.bmp.SetPixel(x, task1Line, color);
                            }
                            isTask1Working = false;
                        }
                    });
                    await Task.Run(() => {

                    });
                    await Task.Run(() => {

                    });
                    await Task.Run(() => {

                    });

                    // 終了判定
                    if ( completeLine >= h )
                    {
                        break;
                    }

                    // 業務委託
                    if ( !isTask1Working )
                    {
                        // 未割り当て
                        if ( task1Line < h )
                        {
                            task1Line++;
                            isTask1Working = true;
                        }
                    }
                }

             */
#endif
        }
    }
}
