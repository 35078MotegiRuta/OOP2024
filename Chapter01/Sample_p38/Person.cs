using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_p38 {
    internal class Person {
        public string Name { get; set; }
        public DateTime BirthDay{ get; set; }
        public int GetAge() {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDay.Year;
            if (today < BirthDay.AddYears(age))
                age--;
            return age;
        }
    }
}
