using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> kenchou = new Dictionary<string, string>();

        static void Main(string[] args) {
            string key, value;

            Console.WriteLine("県庁所在地の登録");

            while (true) {
                Console.Write("都道府県:");
                key = Console.ReadLine();
                if (key == null)
                    break;

                Console.Write("県庁所在地: ");
                value = Console.ReadLine();

                if (kenchou.ContainsKey(key)) {
                    Console.Write("既に登録されています　上書きしますか?(Y/N):");
                    if (Console.ReadLine() == "N") {
                        continue;
                    }
                }
                kenchou[key] = value;
            }

            int input;

            do {
                input = Menu();

                switch (input) {
                    case 1:
                        AllKenchou();
                        break;

                    case 2:
                        SearchKen();
                        break;

                    case 9:
                        Console.WriteLine("終了します");
                        break;

                    default:
                        Console.WriteLine("数字が違うよ");
                        break;
                }
            } while (input != 9);
        }

        private static int Menu() {
            int input;
            Console.WriteLine("*メニュー*");
            Console.WriteLine("1: 一覧表示");
            Console.WriteLine("2: 検索");
            Console.WriteLine("9: 終了");
            Console.WriteLine("----------- ");

            int.TryParse(Console.ReadLine(), out input);
            return input;
        }


        private static void AllKenchou() {
            foreach (var ken in kenchou) {
                Console.WriteLine($"{ken.Key}の県庁所在地は{ken.Value}です");
            }
        }
        
        private static void SearchKen() {
            Console.Write("都道府県:");
            string searchKey = Console.ReadLine();
            if (kenchou.ContainsKey(searchKey)) {
                Console.WriteLine($"{searchKey}の県庁所在地は{kenchou[searchKey]}です");
            } else {
                Console.WriteLine($"{searchKey}は登録されていません");
            }
        }
    }
}