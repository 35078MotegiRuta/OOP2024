using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };

            //Judgement judge = IsEven;
            Judgement judge = IsNotEven;

            int count = Count(numbers, judge);
            Console.WriteLine(count);
        }

        //nが偶数かどうかを調べる
        public static bool IsEven(int n) {
            return n % 2 == 0; //偶数だとtureが返却される
        }

        //nが偶数かどうかを調べる
        public static bool IsNotEven(int n) {
            return n % 2 == 1; //偶数だとtureが返却される
        }


        public delegate bool Judgement(int value);//デリゲートの宣言

        public static int Count(int[] numbers, Judgement judge) {
            
            int count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true)
                    count++;
            }
            return count;
        }

    }
}
