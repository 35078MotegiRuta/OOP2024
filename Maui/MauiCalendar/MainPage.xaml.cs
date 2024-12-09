using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace MauiCalendar {
    public partial class MainPage : ContentPage {
        private DateTime currentMonth = DateTime.Now;

        public MainPage() {
            InitializeComponent();
            InitializeYearAndMonthPickers();
            LoadCalendar(currentMonth);
        }

        // 年と月の Picker を初期化
        private void InitializeYearAndMonthPickers() {
            // 年の選択肢を作成
            List<int> years = new List<int>();
            for (int i = 2020; i <= 2030; i++) {
                years.Add(i);
            }
            YearPicker.ItemsSource = years;
            YearPicker.SelectedItem = currentMonth.Year;

            // 月の選択肢を作成
            List<string> months = new List<string> {
                "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"
            };
            MonthPicker.ItemsSource = months;
            MonthPicker.SelectedItem = currentMonth.ToString("M月");
        }

        // カレンダーを表示する
        private void LoadCalendar(DateTime month) {
            CalendarGrid.Children.Clear();

            // 月の最初の日と最終日を計算
            DateTime firstDayOfMonth = new DateTime(month.Year, month.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // 曜日のラベルを配置
            string[] daysOfWeek = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            for (int i = 0; i < daysOfWeek.Length; i++) {
                var label = new Label {
                    Text = daysOfWeek[i],
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    FontSize = 16
                };
                CalendarGrid.Children.Add(label);
                Grid.SetRow(label, 0);   // 1行目に配置
                Grid.SetColumn(label, i); // 各曜日に配置
            }

            // 日付を配置
            int row = 1;
            int column = (int)firstDayOfMonth.DayOfWeek;

            for (int day = 1; day <= lastDayOfMonth.Day; day++) {
                var dayLabel = new Label {
                    Text = day.ToString(),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    FontSize = 18,
                    Padding = new Thickness(10)
                };

                CalendarGrid.Children.Add(dayLabel);
                Grid.SetRow(dayLabel, row);  // 行に配置
                Grid.SetColumn(dayLabel, column); // 列に配置

                column++;  // 次の列に移動
                if (column > 6)  // 1週間が終わるので次の行に移動
                {
                    column = 0;
                    row++;
                }
            }
        }

        // 前月ボタンがクリックされたときの処理
        private void OnPreviousMonthClicked(object sender, EventArgs e) {
            // 現在の月を前の月に変更
            if (currentMonth.Month == 1) {
                // 1月から12月に戻る場合は、年を1つ戻す
                currentMonth = new DateTime(currentMonth.Year - 1, 12, 1); // 年を1つ戻して12月に
            } else {
                // 月を1つ戻す
                currentMonth = currentMonth.AddMonths(-1);
            }

            LoadCalendar(currentMonth);
            UpdatePickers();
        }

        // 次月ボタンがクリックされたときの処理
        private void OnNextMonthClicked(object sender, EventArgs e) {
            // 現在の月を次の月に変更
            if (currentMonth.Month == 12) {
                // 12月から1月に進む場合は、年を進めて1月に変更する
                currentMonth = new DateTime(currentMonth.Year + 1, 1, 1);
            } else {
                // 月を1つ進める
                currentMonth = currentMonth.AddMonths(1);
            }

            LoadCalendar(currentMonth);
            UpdatePickers();
        }

        // 年と月のPickerを更新
        private void UpdatePickers() {
            YearPicker.SelectedItem = currentMonth.Year;
            MonthPicker.SelectedIndex = currentMonth.Month - 1;  // 月は 0-based インデックスなので1引く
        }

        // 年が選ばれたときの処理
        private void OnYearPickerChanged(object sender, EventArgs e) {
            if (YearPicker.SelectedItem != null && MonthPicker.SelectedItem != null) {
                int selectedYear = (int)YearPicker.SelectedItem;
                int selectedMonth = MonthPicker.SelectedIndex + 1; // 月は 1-based
                currentMonth = new DateTime(selectedYear, selectedMonth, 1);
                LoadCalendar(currentMonth);
            }
        }

        // 月が選ばれたときの処理
        private void OnMonthPickerChanged(object sender, EventArgs e) {
            if (YearPicker.SelectedItem != null && MonthPicker.SelectedItem != null) {
                int selectedYear = (int)YearPicker.SelectedItem;
                int selectedMonth = MonthPicker.SelectedIndex + 1; // 月は 1-based
                currentMonth = new DateTime(selectedYear, selectedMonth, 1);
                LoadCalendar(currentMonth);
            }
        }
    }
}
