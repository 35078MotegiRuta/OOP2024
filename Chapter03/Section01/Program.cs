using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var list = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            var removeCount = list.RemoveAll(s => s.Contains("on"));
            Console.WriteLine(removeCount);

            list.ForEach(s => Console.WriteLine(s));
        }
    }
}
