using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //コンストラクタ
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

        //選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked == true) {
                return CarReport.MakerGroup.トヨタ;
            } else if (rbNissan.Checked == true) {
                return CarReport.MakerGroup.日産;
            } else if (rbHonda.Checked == true) {
                return CarReport.MakerGroup.ホンダ;
            } else if (rbSubaru.Checked == true) {
                return CarReport.MakerGroup.スバル;
            } else if (rbImport.Checked == true) {
                return CarReport.MakerGroup.輸入車;
            } else {
                return CarReport.MakerGroup.その他;
            }
        }
    }
}
