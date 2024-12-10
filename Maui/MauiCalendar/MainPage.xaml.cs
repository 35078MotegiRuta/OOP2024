using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace MauiCalendar {
    public partial class MainPage : ContentPage {
        private DateTime currentMonth = DateTime.Now; // 現在の年月

        public MainPage() {
            InitializeComponent();
            InitializeYearAndMonthPickers();
            UpdateUI(); // 初期化時にUIを更新
        }

        // 年と月の Picker を初期化
        private void InitializeYearAndMonthPickers() {
            int currentYear = DateTime.Now.Year;
            SetYearRange(currentYear); // 年の範囲を設定

            // 月の選択肢を作成
            List<string> months = new List<string> {
                "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"
            };
            MonthPicker.ItemsSource = months;
            MonthPicker.SelectedIndex = currentMonth.Month - 1; // 0-based index
        }

        // 年の範囲を設定（選択された年を中心に前後5年）
        private void SetYearRange(int centerYear) {
            int startYear = centerYear - 5;
            int endYear = centerYear + 5;

            List<int> years = new List<int>();
            for (int i = startYear; i <= endYear; i++) {
                years.Add(i);
            }

            // YearPickerの表示項目を更新
            YearPicker.ItemsSource = years;
            YearPicker.SelectedItem = centerYear; // 現在の年を選択状態にする
        }

        // UIを更新
        private void UpdateUI() {
            LoadCalendar(currentMonth);
            YearPicker.SelectedItem = currentMonth.Year;
            MonthPicker.SelectedIndex = currentMonth.Month - 1; // 0-based index
        }

        private void LoadCalendar(DateTime month) {
            CalendarGrid.Children.Clear();
            string[] daysOfWeek = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            // 曜日ヘッダーを作成
            for (int i = 0; i < daysOfWeek.Length; i++) {
                var label = new Label {
                    Text = daysOfWeek[i],
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    FontAttributes = FontAttributes.Bold
                };
                CalendarGrid.Children.Add(label);
                Grid.SetRow(label, 0);
                Grid.SetColumn(label, i);
            }

            DateTime currentDate = DateTime.Now; // 今日の日付
            DateTime firstDayOfMonth = new DateTime(month.Year, month.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            int row = 1;
            int column = startDayOfWeek;

            // 日付セルを作成
            for (int day = 1; day <= daysInMonth; day++) {
                var dayLabel = new Label {
                    Text = day.ToString(),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Colors.Transparent,
                    Margin = 5
                };

                // 今日の日付を強調
                if (currentDate.Year == month.Year && currentDate.Month == month.Month && currentDate.Day == day) {
                    dayLabel.BackgroundColor = Colors.Yellow; // 背景色で強調
                    dayLabel.FontAttributes = FontAttributes.Bold; // 太字で強調
                }

                // タップジェスチャーを追加
                var tapGesture = new TapGestureRecognizer();
                tapGesture.CommandParameter = day; // 日付を渡す
                tapGesture.Tapped += (s, e) => {
                    if (tapGesture.CommandParameter is int selectedDay) {
                        OnDateTapped(selectedDay, month);
                    }
                };
                dayLabel.GestureRecognizers.Add(tapGesture);

                // 日付セルをカレンダーに追加
                CalendarGrid.Children.Add(dayLabel);
                Grid.SetRow(dayLabel, row);
                Grid.SetColumn(dayLabel, column);

                column++;
                if (column > 6) {
                    column = 0;
                    row++;
                }
            }
        }

        // 日付がタップされたときの処理
        private void OnDateTapped(int day, DateTime month) {
            DisplayAlert("選択された日付", $"{month.Year}年{month.Month}月{day}日が選択されました。", "OK");
        }

        // 前月ボタンがクリックされたとき
        private void OnPreviousMonthClicked(object sender, EventArgs e) {
            currentMonth = currentMonth.AddMonths(-1);
            UpdateUI();
        }

        // 次月ボタンがクリックされたとき
        private void OnNextMonthClicked(object sender, EventArgs e) {
            currentMonth = currentMonth.AddMonths(1);
            UpdateUI();
        }

        // 年ピッカーが変更されたとき
        private void OnYearPickerChanged(object sender, EventArgs e) {
            if (YearPicker.SelectedItem != null) {
                int selectedYear = (int)YearPicker.SelectedItem;
                currentMonth = new DateTime(selectedYear, currentMonth.Month, 1);

                // 年変更時に範囲を再設定
                SetYearRange(selectedYear);

                UpdateUI();
            }
        }

        // 月ピッカーが変更されたとき
        private void OnMonthPickerChanged(object sender, EventArgs e) {
            if (MonthPicker.SelectedIndex != -1) {
                int selectedMonth = MonthPicker.SelectedIndex + 1; // 0-based to 1-based
                currentMonth = new DateTime(currentMonth.Year, selectedMonth, 1);
                UpdateUI();
            }
        }

        // Maui Calendar ボタンがクリックされたとき（現在の日付に戻る）
        private void OnMauiCalendarClicked(object sender, EventArgs e) {
            currentMonth = DateTime.Now; // 現在の日付にリセット
            SetYearRange(currentMonth.Year); // 現在の年に基づいて年範囲を再設定
            UpdateUI(); // UIを更新
        }
    }
}
