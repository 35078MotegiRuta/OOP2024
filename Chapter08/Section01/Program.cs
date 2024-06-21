using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("生年月日を入力");

            Console.Write("年:");
            int year = int.Parse(Console.ReadLine());

            Console.Write("月:");
            int month = int.Parse(Console.ReadLine());

            Console.Write("日:");
            int day = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);
            Console.WriteLine($"あなたは{date.ToString("dddd")}に生まれました");
        }
    }
}
