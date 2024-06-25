using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            tbDisp.Text = today.ToString("g") + "\r\n";
            tbDisp.Text += today.ToString("yyyy年MM月dd日 HH時mm分ss秒") + "\r\n";
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            tbDisp.Text += today.ToString("ggyy年M月d日 (dddd)",culture);
        }
    }
}
