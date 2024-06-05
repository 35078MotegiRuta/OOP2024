using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            string[] parts = line.Split(';');

            foreach (var part in parts) {
                string[] keyValue = part.Split('=');
                string key = keyValue[0];
                string value = keyValue[1];
                Console.WriteLine(ToJapanese(key)+":"+ value);
            }
        }

        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家";

                case "BestWork":
                    return "代表作";

                case "Born":
                    return "誕生年";
            }
            throw new ArgumentException("引数に誤りがあります。");
        }
    }
}
