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
        Utility util;
        
        private int count = 0;

        NoiseManager noiseManager;


        // コンストラクタ
        public Form1()
        {
            InitializeComponent();
            InitComboType();

            timerAnime.Stop();
        }
        
        // コンボボックスの初期化
        private void InitComboType()
        {
            foreach ( string item in noiseManager.itemList )
            {
                this.comboType.Items.Add(item);
            }
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
            //string frand = GetFRand().ToString();
            //UpdateTextLog(string.Format("{0:f5}", frand));

            this.pic.Image = noiseManager.Create(this.comboType.SelectedText);
            timerAnime.Start();
        }

        // アニメーション用タイマー
        private void timerAnime_Tick(object sender, EventArgs e)
        {
            if ( count < 1000 )
            {
                this.pic.Image = noiseManager.Create(this.comboType.SelectedText);
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
            this.pic.Image = noiseManager.Create(this.comboType.SelectedText);
            this.pic.Image.Save(@".\output\test.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}

/*
 * Noise
 * https://qiita.com/Nekomasu/items/37b2c553a4f46738cbba
 * https://so-zou.jp/software/tech/programming/c-sharp/graphics/#no15
 * https://www.ipentec.com/document/csharp-create-color-from-rgb-value
 * https://qiita.com/Tachibana446/items/31cdda5cac78cf571a04
 * 
 * Lerp
 * https://qiita.com/Hirai0827/items/c8bc643c0bcfe5ca9c17#lerpinverselerp
 */
