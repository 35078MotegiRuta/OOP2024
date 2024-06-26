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
            tbDisp.Text += today.ToString("yyyy�NMM��dd�� HH��mm��ss�b") + "\r\n";
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            tbDisp.Text += today.ToString("ggyy�NM��d�� (dddd)", culture) + "\r\n";
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            DateTime date = DateTime.Today;
            foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek))) {
                var str1 = string.Format("{0:yy/MM/dd}�̎��T��{1}:", date, dayOfWeek);
                var str2 = string.Format("{0:yy/MM/dd(ddd)}", NextDay(date, dayOfWeek));
                tbDisp.Text += str1 + str2 + "\r\n";
            }
        }

        public static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);
            var days = (int)dayOfWeek - (int)date.DayOfWeek;
            return date.AddDays(days);
        }

        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = string.Format("�������Ԃ�{0}�~���b�ł���", duration.TotalMilliseconds);
            tbDisp.Text += str + "\r\n";
        }
    }

    class TimeWatch {
        private DateTime _time;

        public void Start() {
            _time = DateTime.Now;
        }
        public TimeSpan Stop() {
            return DateTime.Now - _time;
        }
    }
}
