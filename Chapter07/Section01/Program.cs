using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("県庁所在地の登録");
            var kenchou = new Dictionary<string, string>();

            for (int i = 0; i < 5; i++) {
                Console.WriteLine($"{i+1}件目");
                Console.Write("都道府県:");
                string key = Console.ReadLine();
                Console.Write("県庁所在地: ");
                string value = Console.ReadLine();

                kenchou[key] = value;
            }
            foreach (var x in kenchou) {
                Console.WriteLine($"{x.Key}の県庁所在地は{x.Value}です");
            }
        }
    }
}
