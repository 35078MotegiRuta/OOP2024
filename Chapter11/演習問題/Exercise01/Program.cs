using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load("Sample.xml");
            foreach (var x in xdoc.Root.Elements()) {
                var xname = x.Element("name");
                var member = x.Element("teammembers");
                Console.WriteLine("{0} {1}", xname.Value, member.Value);
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load("Sample.xml");
            var xelements = xdoc.Root.Elements()
                .OrderBy(x => (string)x.Attribute("firstplayed"));
            foreach (var x in xdoc.Root.Elements()) {
                var xname = x.Element("name");
                var xkanji = x.Attribute("kanji");
                Console.WriteLine("{0} {1}", xname.Value, xkanji.Value);
            }
        }

        private static void Exercise1_3(string file) {

        }

        private static void Exercise1_4(string file, string newfile) {

        }
    }
}
