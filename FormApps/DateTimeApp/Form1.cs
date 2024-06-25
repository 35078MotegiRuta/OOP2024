namespace DateTimeApp {
    public partial class btDayBefore : Form {
        public btDayBefore() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {

            DateTime nowDate = DateTime.Today;
            TimeSpan diff = nowDate - dtpDate.Value;

            tbDisp.Text = ($"{diff.Days + 1}“ú–Ú");
        }

        private void btDaybe_Click(object sender, EventArgs e) {
            var before = dtpDate.Value.AddDays(-(double)nudDay.Value);

            tbDisp.Text = before.ToString();
        }

        private void btDayAfter_Click(object sender, EventArgs e) {
            var before = dtpDate.Value.AddDays((double)nudDay.Value);

            tbDisp.Text = before.ToString();
        }
    }
}
