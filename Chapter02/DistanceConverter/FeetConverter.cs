﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    internal class FeetConverter {
        //フィートからメートルを求める
        public double FeetMeter(double meter) {
            return meter * 0.3048;
        }    
        
        //メートルからフィートを求める
        public double MeterFeet(double feet) {
            return feet / 0.3048;
        }
    }
}
