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
    public partial class TestForm : Form
    {
        bool loop_progressbar;
        int num = 0;
        int v1 = 0;
        int v2 = 0;
        int v3 = 0;
        int v4 = 0;

        public TestForm()
        {
            InitializeComponent();
        }

        private void execProgressLoop()
        {
            for ( int i = 0; i <= progressBar1.Maximum; i++ )
            {
                System.Threading.Thread.Sleep(10);
                progressBar1.Value = i;
                label1.Text = i.ToString();
                label1.Update();
            }
        }

        private async void asyncProgree()
        {
            await Task.Run(() =>
            {
                // 処理
                num++;
            });
            loop_progressbar = false;
            MessageBox.Show("Complete.");
        }

#if true
        private async void run()
        {
            for ( int i = 0; i < 100; i++ )
            {
                await Task.Run(() =>
                {
                    // 処理
                    int v = v1;
                    v1 = (v < 100) ? v + 1 : v;
                });
                await Task.Run(() =>
                {
                    // 処理
                    int v = v2;
                    v2 = (v < 100) ? v + 1 : v;
                    System.Threading.Thread.Sleep(10);
                });
                await Task.Run(() =>
                {
                    // 処理
                    int v = v3;
                    v3 = (v < 100) ? v + 1 : v;
                    System.Threading.Thread.Sleep(500);
                });
                await Task.Run(() =>
                {
                    // 処理
                    int v = v4;
                    v4 = (v < 100) ? v + 1 : v;
                    System.Threading.Thread.Sleep(1000);
                });
                progressBar1.Value = v1;
                progressBar2.Value = v2;
                progressBar3.Value = v3;
                progressBar4.Value = v4;
                System.Threading.Thread.Sleep(100);
            }
            MessageBox.Show("complete.");
        }
#else
        // error
        private async void updateProgress(ProgressBar p)
        {
            int v = p.Value;
            p.Value = (v < 100) ? (v + 1) : v;
        }

        private async void run()
        {
            for ( int i = 0; i < 100; i++ )
            {
                await Task.Run(() =>
                {
                    // 処理
                    updateProgress(this.progressBar1);
                });
                await Task.Run(() =>
                {
                    // 処理
                    int v = v2;
                    v2 = (v < 100) ? v + 1 : v;
                    System.Threading.Thread.Sleep(10);
                });
                await Task.Run(() =>
                {
                    // 処理
                    int v = v3;
                    v3 = (v < 100) ? v + 1 : v;
                    System.Threading.Thread.Sleep(500);
                });
                await Task.Run(() =>
                {
                    // 処理
                    int v = v4;
                    v4 = (v < 100) ? v + 1 : v;
                    System.Threading.Thread.Sleep(1000);
                });
                //progressBar1.Value = v1;
                progressBar2.Value = v2;
                progressBar3.Value = v3;
                progressBar4.Value = v4;
                System.Threading.Thread.Sleep(100);
            }
            MessageBox.Show("complete.");
        }
#endif

        private void button1_Click(object sender, EventArgs e)
        {
            run();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
        }
    }
}
