using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noisy
{
    class Utility
    {
        public const int SIZE = 256;
        public const int SEED = 1000;

        Random rand = new Random(SEED);

        // ランダム値の生成
        public float GetFRand()
        {
            return (float)this.rand.NextDouble();
        }

        // tの値によってfromからtoまでの中間値を取得
        public float Lerp(float from, float to, float t)
        {
            //return from + ((from * t) - (to * t));
            return from * (1 - t) + to * t;
        }


    }
}
