using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SampleWeightUnitConverter {
    public class GramUnit : WeightUnit {
        private static List<GramUnit> units = new List<GramUnit> {
            new GramUnit { Name = "mg", Coefficient = 0.001 },
            new GramUnit { Name = "g", Coefficient = 1 },
            new GramUnit { Name = "kg", Coefficient = 1000 },
            new GramUnit { Name = "ton", Coefficient = 1000000 },
        };
        public static ICollection<GramUnit> Units { get { return units; } }

        /// <summary>
        /// ポンド単位からグラム単位に変換します
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="value">値</param>
        /// <returns></returns>

        public double FromPoundUnit(PoundUnit unit,double value) {
            return value * unit.Coefficient * 453.592 / this.Coefficient;
        }
    }
}
