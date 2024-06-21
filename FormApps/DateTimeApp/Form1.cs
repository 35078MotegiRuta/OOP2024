namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {

        }

        private void btDateCount_Click(object sender, EventArgs e) {

            DateTime nowDate = DateTime.Now;
            TimeSpan diff = nowDate - dtpBirthday.Value;

            tbDisp.Text =( $"{diff.Days + 1}“ú–Ú");
        }
    }
}
