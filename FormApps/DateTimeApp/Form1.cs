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

            tbDisp.Text = before.ToString("D");
        }

        private void btDayAfter_Click(object sender, EventArgs e) {
            var after = dtpDate.Value.AddDays((double)nudDay.Value);

            tbDisp.Text = after.ToString("D");
        }

        private void tbAge_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            int age = today.Year - dtpDate.Value.Year;

            tbDisp.Text = age.ToString();
        }
    }
}
