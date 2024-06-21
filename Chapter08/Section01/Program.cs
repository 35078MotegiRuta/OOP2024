using System;
using System.Collections.Generic;
using System.Globalization;
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

            DateTime birthday = new DateTime(year, month, day);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birthday.ToString("ggyy年M月d日",culture);

            //和暦で表示
            Console.WriteLine($"あなたは{str}{birthday.ToString("dddd")}に生まれました");

            //生まれてから何日か
            DateTime nowDate = DateTime.Now;
            Console.WriteLine($"あなたは生まれてから{(int)(nowDate-birthday).TotalDays}日目です。");
        }
    }
}
