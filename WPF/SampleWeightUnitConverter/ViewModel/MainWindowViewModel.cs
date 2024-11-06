using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleWeightUnitConverter {
    internal class MainWindowViewModel : ViewModel {
        private double gramValue, poundValue;

        // ▲ボタンで呼ばれるコマンド (Command called when the ▲ button is pressed)
        public ICommand PoundUnitToGram { get; private set; }
        // ▼ボタンで呼ばれるコマンド (Command called when the ▼ button is pressed)
        public ICommand GramToPoundUnit { get; private set; }

        // 上のcomboBoxで選択されている値 (Value selected in the upper comboBox)
        public GramUnit CurrentGramUnit { get; set; }
        // 下のcomboBoxで選択されている値 (Value selected in the lower comboBox)
        public PoundUnit CurrentPoundUnit { get; set; }

        public double GramValue {
            get { return gramValue; }
            set {
                gramValue = value;
                OnPropertyChanged();
            }
        }
        public double PoundValue {
            get { return poundValue; }
            set {
                poundValue = value;
                OnPropertyChanged();
            }
        }

        //コンストラクタ
        public MainWindowViewModel() {
            this.CurrentGramUnit = GramUnit.Units.First();
            this.CurrentPoundUnit = PoundUnit.Units.First();

            this.GramToPoundUnit = new DelegateCommand(
                () => this.PoundValue = this.CurrentPoundUnit.FromGramUnit(this.CurrentGramUnit, this.GramValue)
            );

            this.PoundUnitToGram = new DelegateCommand(
                () => this.GramValue = this.CurrentGramUnit.FromPoundUnit(this.CurrentPoundUnit, this.PoundValue)
            );
        }
    }
}