using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noisy
{
    class NoiseManager : Utility
    {
        /*
         * 生成するノイズが増えた際は、下記手順を行う
         * 1. インスタンス生成の追加
         * 2. 名称定数の追加
         * 3. itemListに定数追加
         * 4. Create()に呼び出しcaseの追加
         */
        WhiteNoise whiteNoise;
        ValueNoise valueNoise;
        CurlNoise curlNoise;

        public const string WhiteNoise = "White Noise";
        public const string ValueNoise = "Value Noise";
        public const string CurlNoise = "Curl Noise";

        public readonly string[] itemList =
        {
            NoiseManager.WhiteNoise,
            NoiseManager.ValueNoise,
            NoiseManager.CurlNoise
        };

        // 生成関数のスターター
        public Bitmap Create(string target, int w = SIZE, int h = SIZE)
        {
            Bitmap img = null;
            switch ( target )
            {
            case WhiteNoise:
                img = whiteNoise.Create(w, h);
                break;
            case ValueNoise:
                img = valueNoise.Create(w, h);
                break;
            case CurlNoise:
                img = curlNoise.Create(w, h);
                break;
            default:
                break;
            }
            return img;
        }
    }
}
