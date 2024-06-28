using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //�R���X�g���N�^
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Auther = cbAuther.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                //Picture = pbPicture
            };
            listCarReports.Add(carReport);
        }

        //�I������Ă��郁�[�J�[����񋓌^�ŕԂ�
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked == true) {
                return CarReport.MakerGroup.�g���^;
            } else if (rbNissan.Checked == true) {
                return CarReport.MakerGroup.���Y;
            } else if (rbHonda.Checked == true) {
                return CarReport.MakerGroup.�z���_;
            } else if (rbSubaru.Checked == true) {
                return CarReport.MakerGroup.�X�o��;
            } else if (rbImport.Checked == true) {
                return CarReport.MakerGroup.�A����;
            } else {
                return CarReport.MakerGroup.���̑�;
            }
        }
    }
}
