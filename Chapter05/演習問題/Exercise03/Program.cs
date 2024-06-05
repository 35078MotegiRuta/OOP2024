using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            var text2 = "Jackdaws,love,my,big,sphinx,of-quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            Console.WriteLine("-----");

            Exercise3_6(text2);
        }

        private static void Exercise3_1(string text) {
            var count = text.Count(c => c == ' ');
            Console.WriteLine("空白文字:{0}", count);
        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            var str = text.Split(' ').Length;
            Console.WriteLine("{0}",str);
        }

        private static void Exercise3_4(string text) {
            var str = text.Split(' ').Where(w => w.Length <= 4);
            foreach(var w in str) {
                Console.WriteLine(w); 
            }
        }

        private static void Exercise3_5(string text) {
            var str = text.Split(' ').ToArray();
            var sb = new StringBuilder();
            foreach (var w in str) {
                sb.Append(w).Append(' ');
            }
            Console.Write(sb);
        }


        //private static void Exercise3_5(string text) {
        //    var array = text.Split(' ').ToArray();

        //    if(array.Length  > 0) {
        //        var sb = new StringBuilder(array[0]);
        //        foreach (var w in array.Skip(1)) {
        //            sb.Append(w).Append(' ');
        //        }
        //    Console.Write(sb);
        //}

        private static void Exercise3_6(string text2) {
            var array = text2.Split(new[] {' ',',','-','_'}).ToArray();
            foreach (var w in array) {
                Console.WriteLine(w);
            }
        }
    }
}
