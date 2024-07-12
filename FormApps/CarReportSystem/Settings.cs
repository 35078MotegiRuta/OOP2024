using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {

        private static Settings instance; //自分自身のインスタンスを取得

        public int MainFromColor { get; set; }
        
        //コンストラクタ
        private Settings() { }

        public static Settings getInsutance() {
            if (instance == null) {
                instance = new Settings();
            }
            return instance;
        }
    }
}
