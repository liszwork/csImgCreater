using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noisy
{
    public partial class Form1 : Form
    {
        public readonly int SIZE = 256;
        public readonly int SEED = 1000;
        public Form1()
        {
            InitializeComponent();
            this.pic.Image = CreateWhiteNoise();
        }
        public Bitmap CreateWhiteNoise()
        {
            double[,] noise = new double[SIZE, SIZE];
            Random r = new Random(1000);
            Bitmap bmp = new Bitmap(SIZE, SIZE);
            for ( int y = 0; y < SIZE; y++ )
            {
                string msg = "";
                for ( int x = 0; x < SIZE; x++ )
                {
                    float value = (float)r.NextDouble();
                    msg += value.ToString() + " ";

                    int v = (int)(value * 100.0);
                    Color color = Color.FromArgb(255, v, v, v);
                    bmp.SetPixel(x, y, color);
                }
                Console.Write(msg + "\n");
            }
            return bmp;
        }
    }
}

/*
 * https://qiita.com/Nekomasu/items/37b2c553a4f46738cbba
 * https://so-zou.jp/software/tech/programming/c-sharp/graphics/#no15
 * https://www.ipentec.com/document/csharp-create-color-from-rgb-value
 * https://qiita.com/Tachibana446/items/31cdda5cac78cf571a04
*/
