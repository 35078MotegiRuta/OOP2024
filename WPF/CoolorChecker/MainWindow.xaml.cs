using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoolorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        MyColor currentColor;

        public MainWindow() {
            InitializeComponent();
            currentColor.Color = Color.FromArgb(255, 0, 0, 0);
            colorSelectComboBox.DataContext = GetColorList();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            currentColor.Name = $"R: {currentColor.Color.R}, G: {currentColor.Color.G}, B: {currentColor.Color.B}";
            colorArea.Background = new SolidColorBrush(currentColor.Color);
        }

        private void StockButton_Click(object sender, RoutedEventArgs e) {
            var sliderColor = currentColor.Color;

            var namedColor = GetColorList().FirstOrDefault(c => c.Color == sliderColor);

            if (namedColor.Name != null) {
                if (!stockList.Items.Cast<MyColor>().Any(item => item.Equals(namedColor))) {
                    stockList.Items.Insert(0, namedColor);
                } else {
                    MessageBox.Show("既に登録済みの色です！", "CoolorChecker", MessageBoxButton.OK);
                }
            } else {
                var myColor = new MyColor { Color = sliderColor, Name = $"R: {sliderColor.R}, G: {sliderColor.G}, B: {sliderColor.B}" };
                if (!stockList.Items.Cast<MyColor>().Any(item => item.Equals(myColor))) {
                    stockList.Items.Insert(0, myColor);
                } else {
                    MessageBox.Show("既に登録済みの色です！", "CoolorChecker", MessageBoxButton.OK);
                }
            }
        }

        private void StockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selectedColor) {
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
                rSlider.Value = selectedColor.Color.R;
                gSlider.Value = selectedColor.Color.G;
                bSlider.Value = selectedColor.Color.B;
            }
        }

        private void ColorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorSelectComboBox.SelectedItem is MyColor selectedColor) {
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
                currentColor = selectedColor; // 追加: 現在の色を更新
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) {
            // ストックリストで選択されたアイテムがあるかチェック
            if (stockList.SelectedItem is MyColor selectedColor) {
                // 選択された色をストックリストから削除
                stockList.Items.Remove(selectedColor);
                MessageBox.Show("色が削除されました。", "CoolorChecker", MessageBoxButton.OK);
            } else {
                // 何も選択されていない場合の警告
                MessageBox.Show("削除する色を選択してください。", "CoolorChecker", MessageBoxButton.OK);
            }
        }
    }
}
