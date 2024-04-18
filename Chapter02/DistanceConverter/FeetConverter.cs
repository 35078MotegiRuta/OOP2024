using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    internal class FeetConverter {      
        //メートルからフィートを求める
        public static double MeterFeet(double meter) {
            return meter / 0.3048;
        }
        //フィートからメートルを求める
        public static double FeetMeter(double feet) {
            return feet * 0.3048;
        }    

    }
}
