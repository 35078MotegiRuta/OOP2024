using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            tbDisp.Text = today.ToString("g") + "\r\n";
            tbDisp.Text += today.ToString("yyyyîNMMåéddì˙ HHéûmmï™ssïb") + "\r\n";
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            tbDisp.Text += today.ToString("ggyyîNMåédì˙ (dddd)", culture) + "\r\n";
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            DateTime date = DateTime.Today;
            foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek))) {
                DateTime nextDay = NextDay(date, dayOfWeek);
                var str = string.Format("{0:yy/MM/dd}ÇÃéüèTÇÃ{1}:{2:yy/MM/dd}", date,dayOfWeek,nextDay);
                tbDisp.Text += str + "\r\n";
            }
        }

        public static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)date.DayOfWeek;
            if (days <= 0) {
                days += 7;
            }
            return date.AddDays(days);
        }
    }
}
