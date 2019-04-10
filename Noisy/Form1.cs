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
        Random rand = new Random(1000);
        private int count = 0;

        public Form1()
        {
            InitializeComponent();
            this.pic.Image = CreateWhiteNoise();
            timer1.Stop();
        }
        public Bitmap CreateWhiteNoise()
        {
            double[,] noise = new double[SIZE, SIZE];
            Bitmap bmp = new Bitmap(SIZE, SIZE);
            for ( int y = 0; y < SIZE; y++ )
            {
                string msg = "@";
                for ( int x = 0; x < SIZE; x++ )
                {
                    float value = GetFRand();
                    msg += value.ToString() + " ";

                    int v = (int)(value * 100.0);
                    Color color = Color.FromArgb(255, v, v, v + 100);
                    bmp.SetPixel(x, y, color);
                }
                //UpdateTextLog(msg);
            }
            return bmp;
        }

        private float GetFRand()
        {
            return (float)this.rand.NextDouble();
        }

        private void UpdateTextLog(string log, bool isClear = false)
        {
            if ( isClear )
            {
                this.textLog.Text = "";
            }
            this.textLog.Text = log + "\r\n" + this.textLog.Text;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string frand = GetFRand().ToString();
            UpdateTextLog(string.Format("{0:f5}", frand));

            this.pic.Image = CreateWhiteNoise();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ( count < 1000 )
            {
                this.pic.Image = CreateWhiteNoise();
                count++;
            }
            else
            {
                timer1.Stop();
                count = 0;
            }
            UpdateTextLog(count.ToString(), true);
        }
    }
}

/*
 * https://qiita.com/Nekomasu/items/37b2c553a4f46738cbba
 * https://so-zou.jp/software/tech/programming/c-sharp/graphics/#no15
 * https://www.ipentec.com/document/csharp-create-color-from-rgb-value
 * https://qiita.com/Tachibana446/items/31cdda5cac78cf571a04
*/
