using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
                 .OrderByDescending(x => int.Parse(x.Element("teammembers").Value))
                 .First();

            var xname = xelements.Element("name").Value;

            Console.WriteLine("{0}", xname);
        }

        private static void Exercise1_4(string file, string newfile) {
            List<XElement> xElements = new List<XElement>();

            var xdoc = XDocument.Load(file);

            int nextFlag;

            while (true) {
                //入力
                Console.Write("名称:");
                string name = Console.ReadLine();

                Console.Write("漢字:");
                string kanji = Console.ReadLine();

                Console.Write("人数:");
                string teammembers = Console.ReadLine();

                Console.Write("起源:");
                string firstplayed = Console.ReadLine();

                var element = new XElement("ballsport",
                    new XElement("name", name, new XAttribute("kanji", kanji)),
                    new XElement("teammembers", teammembers),
                    new XElement("firstplayed", firstplayed)
                );

                xElements.Add(element);//リストに要素追加

                Console.WriteLine();
                Console.WriteLine("追加(1)/保存(2)");
                Console.Write(">");
                nextFlag = int.Parse(Console.ReadLine());
                    if (nextFlag == 2) {
                        break;//ループ終了
                }
                Console.WriteLine();
                xdoc.Root.Add(element);
                xdoc.Save(newfile);//保存
            }
        }
    }
}
