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

            int count = 0;
            while (count < 5) {
                Console.Write("都道府県:");
                string key = Console.ReadLine();
                Console.Write("県庁所在地: ");
                string value = Console.ReadLine();

                if (kenchou.ContainsKey(key)) {
                    Console.Write("既に登録されています　上書きしますか?(Y/N):");
                    if (Console.ReadLine() == "N") {
                        continue;
                    }
                }
                kenchou[key] = value;
                count++;
            }

            int input;

            do {
                Console.WriteLine("*メニュー*");
                Console.WriteLine("1: 一覧表示");
                Console.WriteLine("2: 検索");
                Console.WriteLine("9: 終了");
                Console.WriteLine("----------- ");

                int.TryParse(Console.ReadLine(), out input);

                switch (input) {
                    case 1:
                        foreach (var ken in kenchou) {
                            Console.WriteLine($"{ken.Key}の県庁所在地は{ken.Value}です");
                        }
                        break;

                    case 2:
                        Console.Write("都道府県:");
                        string searchKey = Console.ReadLine();
                        if (kenchou.ContainsKey(searchKey)) {
                            Console.WriteLine($"{searchKey}の県庁所在地は{kenchou[searchKey]}です");
                        } else {
                            Console.WriteLine($"{searchKey}は登録されていません");
                        }
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
    }
}