using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("一つ目の文字列を入力してください:");
            var str1 = Console.ReadLine();
            Console.Write("二つ目の文字列を入力してください:");
            var str2 = Console.ReadLine();
            if (String.Compare(str1, str2, true) == 0) {
                Console.WriteLine("等しいです");
            }else{
                Console.WriteLine("等しくないです"); 
            }
        }
    }
}
