using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employees.json"));
        }

        private static void Exercise1_1(string outfile) {
            var employee = new Employee {
                Id = 100,
                Name = "山田太郎",
                HireDate = new DateTime(2000,1,1),
            };

            var settings = new XmlWriterSettings {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };

            using (var emplo = XmlWriter.Create(outfile, settings)) {
                var serializer = new XmlSerializer(typeof(Employee));
                serializer.Serialize(emplo, employee);
            }
        }

        private static void Exercise1_2(string outfile) {

        }

        private static void Exercise1_3(string file) {

        }

        private static void Exercise1_4(string file) {

        }
    }
}
