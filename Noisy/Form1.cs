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

        public const int SIZE = 256;
        public const int SEED = 1000;
        Random rand = new Random(SEED);
        private int count = 0;

        public Form1()
        {
            InitializeComponent();
            this.pic.Image = CreateWhiteNoise();
            timerAnime.Stop();
        }

        private void initComboType()
        {
            // TODO: comboboxで表示するものの週別を選べるようにする,ここで一覧データ作成
        }

        // ホワイトノイズの出力
        public Bitmap CreateWhiteNoise(int w = SIZE, int h = SIZE)
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
        }

        public Bitmap CreateValueNoise(int size = SIZE)
        {
            double[,] noise = new double[size, size];
            /*
                   v01         v11
                   .-----------.
               y  /           /
                 /           /
                /           /
               .-----------.
             v00     x     v01
             */
            // 四隅の頂点をランダム値で決定
            float v00 = GetFRand();
            float v01 = GetFRand();
            float v10 = GetFRand();
            float v11 = GetFRand();


            return null;
        }

        // ランダム値の生成
        private float GetFRand()
        {
            return (float)this.rand.NextDouble();
        }

        // ログテキストエリアへの出力
        private void UpdateTextLog(string log, bool isClear = false)
        {
            if ( isClear )
            {
                this.textLog.Text = "";
            }
            this.textLog.Text = log + "\r\n" + this.textLog.Text;
        }

        // 更新ボタンクリック
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string frand = GetFRand().ToString();
            UpdateTextLog(string.Format("{0:f5}", frand));

            this.pic.Image = CreateWhiteNoise();
            timerAnime.Start();
        }

        // アニメーション用タイマー
        private void timerAnime_Tick(object sender, EventArgs e)
        {
            if ( count < 1000 )
            {
                this.pic.Image = CreateWhiteNoise();
                count++;
            }
            else
            {
                timerAnime.Stop();
                count = 0;
            }
            UpdateTextLog(count.ToString(), true);
        }

        // 保存
        private void buttonSave_Click(object sender, EventArgs e)
        {
            int w = int.Parse(textWeight.Text);
            int h = int.Parse(textHeight.Text);
            this.pic.Image = CreateWhiteNoise(w, h);
            this.pic.Image.Save(@".\output\test.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}

/*
 * https://qiita.com/Nekomasu/items/37b2c553a4f46738cbba
 * https://so-zou.jp/software/tech/programming/c-sharp/graphics/#no15
 * https://www.ipentec.com/document/csharp-create-color-from-rgb-value
 * https://qiita.com/Tachibana446/items/31cdda5cac78cf571a04
*/
