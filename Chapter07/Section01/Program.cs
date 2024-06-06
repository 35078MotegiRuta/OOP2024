using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var employeeDict = new Dictionary<int, Employee> {
               { 100, new Employee(100, "清水遼久") },
               { 112, new Employee(112, "芹沢洋和") },
               { 125, new Employee(125, "岩瀬奈央子") },
            };

            employeeDict.Add(126, new Employee(126, "庄野遥花"));

            foreach (var item in employeeDict.Values) {
                Console.WriteLine($"{item.Id} {item.Name}");
            }

            //var flowerDict = new Dictionary<string, int>() {
            //    { "sunflower", 400 },
            //    { "pansy", 300 },
            //    { "tulip", 350 },
            //    { "rose", 500 },
            //    { "dahlia", 450 },
            //};
            //Console.WriteLine(flowerDict["sunflower"]);
            //Console.WriteLine(flowerDict["dahlia"]);
        }
    }
}
