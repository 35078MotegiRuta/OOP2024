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
            var xdoc = XDocument.Load(file);
            var xelements = xdoc.Root.Elements();

            foreach (var x in xelements) {
                var xname = x.Element("name");
                var xmember = x.Element("teammembers");
                Console.WriteLine("{0} {1}", xname.Value, xmember.Value);
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var xelements = xdoc.Root.Elements()
                   .OrderBy(x => x.Element("firstplayed").Value);

            foreach (var x in xelements) {
                var xname = x.Element("name");
                var xkanji = xname.Attribute("kanji");
                var xfirstplayed = x.Element("firstplayed"); 
                Console.WriteLine("{0} ({1})", xkanji.Value, xfirstplayed.Value);
            }
        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var xelements = xdoc.Root.Elements()
                 .OrderByDescending(x => x.Element("teammembers").Value)
                 .First();

            var xname = xelements.Element("name").Value;

            Console.WriteLine("{0}", xname);
        }

        private static void Exercise1_4(string file, string newfile) {

        }
    }
}
