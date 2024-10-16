using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor; 

namespace TextNumberSizeChange {
    class ToHankakuProcessor : TextProcessor{

        private Dictionary<char, char> _conversionMap;

        protected override void Initialize(string fname) {
            _conversionMap = new Dictionary<char, char> {
                { '０', '0' },
                { '１', '1' },
                { '２', '2' },
                { '３', '3' },
                { '４', '4' },
                { '５', '5' },
                { '６', '6' },
                { '７', '7' },
                { '８', '8' },
                { '９', '9' }
            };
        }

        protected override void Execute(string line) {
            foreach (var kvp in _conversionMap) {
                line = line.Replace(kvp.Key, kvp.Value);
            }
            Console.WriteLine(line);
        }

        protected override void Terminate() {

        }
    }
}
