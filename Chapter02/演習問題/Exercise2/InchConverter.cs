using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    public class InchConverter {
        //private const double ratio = 0.0254; //定数
        public static readonly double ratio = 0.0254; //定数(外部にも公開する場合)


        //メートルからインチを求める
        public static double MeterInch(double meter) {
            return meter / ratio;
        }
        //インチからメートルを求める
        public static double InchMeter(double inch) {
            return inch * ratio;
        }
    }
}
