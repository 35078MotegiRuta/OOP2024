using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("数字文字列を入力してください:");
            var numStr = Console.ReadLine();
            if(int.TryParse(numStr, out int num)) {
                Console.WriteLine(num.ToString("#,0"));
            }
        }
    }
}
